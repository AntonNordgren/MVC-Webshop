using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class OrderRepository //: IOrderRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly ShoppingCartActions _shoppingCartActions;
       


        public OrderRepository(BookStoreDbContext bookStoreDbContext, ShoppingCartActions shoppingCartActions)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _shoppingCartActions = shoppingCartActions;
            
        }   

        
    }
}








