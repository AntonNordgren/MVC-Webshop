using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly ShoppingCartActions _shoppingCartActions;

        public OrderRepository(BookStoreDbContext bookStoreDbContext, ShoppingCartActions shoppingCartActions)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _shoppingCartActions = shoppingCartActions;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            var cartItems = _shoppingCartActions.CartItems;
            order.TotalCost = _shoppingCartActions.GetCartTotal();
            order.OrderItems = new List<OrderItem>();


            //order.OrderItems = new List<OrderItem>();
          

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Book.UnitPrice,
                    Discount = 0,
                    BookId = cartItem.BookId,
                    OrderId = cartItem.Id,  
                };

                order.OrderItems.Add(orderItem);
            }

            _bookStoreDbContext.Orders.Add(order);

            _bookStoreDbContext.SaveChanges();
        }
    }
}








