using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ebook.Models;

namespace ebook.Repositories
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        private ApplicationDbContext context;

        public HomeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByCategory(int category)
        {
            return context.Books.Where(x => (int)x.Category == category).ToList();
        }

        public IEnumerable<Book> GetBooksByBasicSearch(string search)
        {
            return context.Books.Where(x => x.BookName.Contains(search) || x.Author.Contains(search)).ToList();
        }

        public IEnumerable<Book> GetBooksByAdvancedSearch(string bookName, string authorName, int Category)
        {
            return context.Books.Where(x => x.BookName.Contains(bookName) && x.Author.Contains(authorName) && (int)x.Category == Category).ToList();
        }

        public Book GetBookByID(Guid id)
        {
            return context.Books.Find(id);
        }

        public void InsertBook(Book book)
        {
            context.Books.Add(book);
        }

        public void DeleteBook(Guid bookID)
        {
            Book book = context.Books.Find(bookID);
            context.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}