using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ebook.Models;
using ebook.Repositories;
using ebook.ViewModels;

namespace ebook.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository homeRepository;

        public HomeController()
        {
            homeRepository = new HomeRepository(new ApplicationDbContext());
        }

        public ActionResult Index()
        {
        /*    if(User.IsInRole(RoleName.IsAdmin))
                return View("AddResources"); */
            return View();
        }

        [Authorize(Roles = RoleName.IsAdmin)]
        public ActionResult AddResources()
        {
            return View();
        }

        [Authorize(Roles = RoleName.IsAdmin)]
        public ActionResult EditResources(Book book)
        {
            return View("AddResources", book);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.IsAdmin)]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdateResources(Book book)
        {
            if(book.BookId != Guid.Empty)
            {
                homeRepository.UpdateBook(book);
                homeRepository.Save();
                return RedirectToAction("ViewResources");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        homeRepository.InsertBook(book);
                        homeRepository.Save();
                        TempData["successMessage"] = "The Book Details are Added successfully";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    // System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                    ModelState.AddModelError(string.Empty, e.InnerException.Message);
                }
            }
            return View("AddResources");
        }

        public ActionResult ViewResources()
        {
            IEnumerable<Book> books = homeRepository.GetBooks();
            var viewModel = new NewBookViewModel
            {
                BookList = books
            };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult GetBooksListByCategory(int category)
        {
            IEnumerable<Book> bookByCategory = homeRepository.GetBooksByCategory(category);
            var viewModel = new NewBookViewModel
            {
                BookList = bookByCategory
            };
            return View("ViewResources", viewModel);
        }

        [HttpGet]
        public ActionResult SimpleSearch(string search)
        {
            IEnumerable<Book> bookListBySimpleSearch = homeRepository.GetBooksByBasicSearch(search);
            var viewModel = new NewBookViewModel
            {
                BookList = bookListBySimpleSearch
            };
            return View("ViewResources", viewModel);
        }

        [HttpGet]
        public ActionResult AdvancedSearch(string bookName, string authorName, int Category)
        {
            IEnumerable<Book> bookListBySimpleSearch = homeRepository.GetBooksByAdvancedSearch(bookName, authorName, Category);
            var viewModel = new NewBookViewModel
            {
                BookList = bookListBySimpleSearch
            };
            return View("ViewResources", viewModel);
        }

        public ActionResult ViewSingleBook(Guid bookId)
        {
            if(bookId != null)
            {
                Book book = homeRepository.GetBookByID(bookId);
                return View(book);
            }
            return RedirectToAction("ViewResources");
        }

        [Authorize(Roles = RoleName.IsAdmin)]
        public ActionResult DeleteSingleBookRecord(Guid bookId)
        {
            try
            {
                homeRepository.DeleteBook(bookId);
                homeRepository.Save();
            }
            catch (DataException /* dex */)
            {
                return RedirectToAction("ViewSingleBook", bookId);
            }
            return RedirectToAction("ViewResources");
        }
    }
}