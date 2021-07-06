using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ebook.Models;

namespace ebook.ViewModels
{
    public class NewBookViewModel
    {
        public IEnumerable<Book> BookList { get; set; }

        public BookCategory Category { get; set; }
    }
}