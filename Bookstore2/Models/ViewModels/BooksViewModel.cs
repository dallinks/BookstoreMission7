using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models.ViewModels
{
    //Kept the name ProjectsViewModel bc I was nervous to change it, still works.
    public class BooksViewModel
    {
        public IQueryable<Book> Book { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
