using System;
using System.Collections.Generic;
using ebook.Models;

namespace ebook.Repositories
{
    public interface IHomeRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();

        IEnumerable<Book> GetBooksByCategory(int category);

        IEnumerable<Book> GetBooksByBasicSearch(string search);

        IEnumerable<Book> GetBooksByAdvancedSearch(string bookName, string authorName, int Category);
        Book GetBookByID(Guid bookId);
        void InsertBook(Book book);
        void DeleteBook(Guid bookId);
        void UpdateBook(Book book);
        void Save();
    }
}