using MVC_Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Webshop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using MVC_Webshop.ViewModels;

namespace MVC_Webshop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
       // private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCartActions _shoppingCartActions;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookStoreDbContext _bookStoreDbContext;
        private string currentUserId;
        private string currentUserName;


                                //, IOrderRepository orderRepository
        public OrderController(BookStoreDbContext bookStoreDbContext, ShoppingCartActions shoppingCartActions, UserManager<ApplicationUser> userManager)
        {
       
            _shoppingCartActions = shoppingCartActions;
            _userManager = userManager;
            _bookStoreDbContext = bookStoreDbContext;
        }
        public IActionResult Historia()
        {
            currentUserId = _userManager.GetUserId(User);
            OrderViewModel model = new OrderViewModel();
            model.Orders = _bookStoreDbContext.Orders.Where(x => x.UserId == currentUserId).ToList();
            model.Users = _bookStoreDbContext.Users.ToList();
            
            return View(model);
        }
        
        public IActionResult PlaceOrder()
        {

            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            currentUserId = _userManager.GetUserId(User);
            


            var items = _shoppingCartActions.GetCartItems();
            _shoppingCartActions.CartItems = items;

            if (_shoppingCartActions.CartItems.Count == 0)
            {
                return Redirect("~/Home/Index");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
              
                var orders = _shoppingCartActions.CartItems;
                return RedirectToAction("OrderSummary");
            }
            return View(order);
        }


        public IActionResult Payment()
        {
            var items = _shoppingCartActions.GetCartItems();
            _shoppingCartActions.CartItems = items;

            if (_shoppingCartActions.CartItems.Count == 0 )
            {
                return Redirect("~/Home/Index");
            }
            if (ModelState.IsValid)
            {
                return View();
            }
                return View();
        }


        public IActionResult OrderSummary ()
        {
            ViewBag.OrderDoneMessage = "Thank you so much for your order. We really appreciate your business and hope that you love your purchase.";
            var items = _shoppingCartActions.GetCartItems();
            _shoppingCartActions.CartItems = items;

            var shoppingCartActionsViewModel = new ShoppingCartActionsViewModel
            {
                ShoppingCartActions = _shoppingCartActions,
                CartTotal = _shoppingCartActions.GetCartTotal()
            };
            _shoppingCartActions.CleanCart();
            
            return View(shoppingCartActionsViewModel);
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            var cartItems = _shoppingCartActions.CartItems;
            order.TotalCost = _shoppingCartActions.GetCartTotal();
            order.OrderItems = new List<OrderItem>();
            order.OrderStatus = "Order Created";
            order.UserId = currentUserId;
         

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Book.UnitPrice,
                    Discount = 0,
                    BookId = cartItem.Book.Id,
                    //OrderId = cartItem.Order.Id,  
                };

                order.OrderItems.Add(orderItem);
            }

            _bookStoreDbContext.Orders.Add(order);

            _bookStoreDbContext.SaveChanges();
        }

    }
}

