using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ebook.Models;
using ebook.Repositories;

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
            ViewBag.Message = "Admin Add Resource Page.";

            return View();
        }

        [HttpPost]
        [Authorize(Roles = RoleName.IsAdmin)]
        [ValidateAntiForgeryToken]
        public ActionResult AddResources(Book book)
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
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}