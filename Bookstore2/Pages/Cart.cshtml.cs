using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore2.Infrastructure;
using Bookstore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore2.Pages
{
    public class CartModel : PageModel
    {
        private BookstoreContext context { get; set; }
        public CartModel (BookstoreContext temp)
        {
            context = temp;
        }
        public Cart Cart {get;set;}
        public string ReturnURL { get; set; }
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookID, string returnURL)
        {
            Book p = context.Books.FirstOrDefault(x => x.BookId == bookID);

            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.AddItem(p, 1);

            HttpContext.Session.SetJson("Cart", Cart);

            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
