using Bookstore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Controllers
{
    public class OrderController : Controller
    {
        private BookstoreContext context { get; set; }
        private Cart cart { get; set; }
        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);
        public OrderController(BookstoreContext temp, Cart c)
        {
            context = temp;
            cart = c;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Items.ToArray();

                context.AttachRange(order.Lines.Select(x => x.Book));
                if (order.DonationId == 0)
                {
                    context.Orders.Add(order);
                }

                context.SaveChanges();

                cart.ClearCart();
                return RedirectToPage("/OrderConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
