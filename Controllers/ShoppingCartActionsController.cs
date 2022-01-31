using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class ShoppingCartActionsController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ShoppingCartActions _shoppingCartActions;

        //constructor injection
        public ShoppingCartActionsController(IBookRepository bookRepository,ShoppingCartActions shoppingCartActions)
        {
            _bookRepository = bookRepository;
            _shoppingCartActions = shoppingCartActions;

        }
        public IActionResult Index()
        {
            
            var items = _shoppingCartActions.GetCartItems();
            _shoppingCartActions.CartItems = items;

            var shoppingCartActionsViewModel = new ShoppingCartActionsViewModel
            {
                ShoppingCartActions = _shoppingCartActions,
                CartTotal = _shoppingCartActions.GetCartTotal()
            };

            return View(shoppingCartActionsViewModel);    
        }


        // add book to cart
        public RedirectToActionResult AddToCart(int bookId)
        {
            var selectedbook = _bookRepository.AllBooks.FirstOrDefault(b => b.Id == bookId);
            
            Console.WriteLine(bookId);
           
            if (selectedbook != null)
            {
                _shoppingCartActions.AddToCart(selectedbook, 1);
            }
            return RedirectToAction("Index");
        }

        // Remove 
        public RedirectToActionResult RemoveFromCart(int bookId)
        {
            var selectedbook = _bookRepository.AllBooks.FirstOrDefault(b => b.Id == bookId);

            if (selectedbook != null)
            {
                _shoppingCartActions.RemoveFromCart(selectedbook);
            }
            return RedirectToAction("Index");
        }


        public RedirectToActionResult UpdateCart(int bookId, int quantity)
        {
            var selectedbook = _bookRepository.AllBooks.FirstOrDefault(b => b.Id == bookId);

            if (selectedbook != null)
            {
                _shoppingCartActions.UpdateCart(selectedbook , quantity);
            }
            return RedirectToAction("Index");
        }
    }
}
