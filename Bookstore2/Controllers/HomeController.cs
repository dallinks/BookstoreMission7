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

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new ProjectsViewModel
            {
                Book = context.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumProjects = context.Books.Count(),
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
