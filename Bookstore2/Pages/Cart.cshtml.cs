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
        public CartModel(BookstoreContext temp, Cart c)
        {
            context = temp;
            Cart = c;
        }
        public Cart Cart { get; set; }
        public string ReturnURL { get; set; }
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
        }
        public IActionResult OnPostRemove(int bookId, string returnURL)
        {
            Cart.RemoveItem(Cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnURL = returnURL });
        }
        public IActionResult OnPost(int bookID, string returnURL)
        {
            Book p = context.Books.FirstOrDefault(x => x.BookId == bookID);

            Cart.AddItem(p, 1);

            return RedirectToPage(new { ReturnURL = returnURL });
        }

    }
}
