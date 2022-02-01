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

            var CartItems = _shoppingCartActions.CartItems;
            order.TotalCost = _shoppingCartActions.GetCartTotal();
            order.OrderItems = new List<OrderItem>();


            order.OrderItems = new List<OrderItem>();
          

            foreach (var CartItem in CartItems)
            {
                var OrderItem = new OrderItem
                {
                    Quantity = CartItem.Quantity,
                    BookId = CartItem.BookId,
                    Book = CartItem.Book,
                    UnitPrice = CartItem.Book.UnitPrice,
                };

                order.OrderItems.Add(OrderItem);
            }

            _bookStoreDbContext.Orders.Add(order);

            _bookStoreDbContext.SaveChanges();
        }
    }
}








