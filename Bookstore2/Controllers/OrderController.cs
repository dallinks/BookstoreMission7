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
        private IOrderRepository repository { get; set; }
        private Cart cart { get; set; }
        public OrderController(IOrderRepository temp, Cart c)
        {
            repository = temp;
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

                repository.SaveOrder(order);

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
