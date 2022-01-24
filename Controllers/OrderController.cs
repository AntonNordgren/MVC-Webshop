using MVC_Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCartActions _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCartActions shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.CartItems;
            _shoppingCart.CartItems = items;

            if (_shoppingCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some Book first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        // CheckoutComplete behövs eller inte
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. Your book come efter 5 Days";
            return View();
        }
    }
}

