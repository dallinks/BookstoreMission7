using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore2.Models;

namespace Bookstore2.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IStoreRepository repo { get; set; }
        public CategoriesViewComponent (IStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var categories = repo.Books
                .Select(s => s.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}
