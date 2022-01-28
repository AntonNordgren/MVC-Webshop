using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Data;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly ShoppingCartActions _shoppingCartActions;
        public CartSummary(ShoppingCartActions shoppingCartActions)
        {
            _shoppingCartActions = shoppingCartActions;
        }

        public IViewComponentResult Invoke()
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

    }
}
