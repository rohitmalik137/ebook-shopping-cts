using System;
using System.Collections.Generic;
using ebook.Models;

namespace ebook.Repositories
{
    public interface IHomeRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int studentID);
        void UpdateBook(Book book);
        void Save();
    }
}