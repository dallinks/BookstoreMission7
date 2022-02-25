using Bookstore2.Models;
using Bookstore2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set; }
        public HomeController (BookstoreContext temp)
        {
            context = temp;
        }

        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Book = context.Books
                .Where(x => x.Category == Category || Category == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumProjects = 
                    (Category == null
                        ? context.Books.Count()
                        :context.Books.Where(x=>x.Category == Category).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            var blah = context.Books.ToList()
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);
            return View(x);
        }
    }
}
