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
        private readonly ShoppingCartActions _shoppingCartActions;

        public OrderController(IOrderRepository orderRepository, ShoppingCartActions shoppingCartActions)
        {
            _orderRepository = orderRepository;
            _shoppingCartActions = shoppingCartActions;
        }

        
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCartActions.GetCartItems();
            _shoppingCartActions.CartItems = items;

            if (_shoppingCartActions.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "To place an order,please add books to the cart");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCartActions.ClearCart();
                return RedirectToAction("OrderReceived");
            }
            return View(order);
        }
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. Your book come efter 5 Days";
            return View();
        }
    }
}

