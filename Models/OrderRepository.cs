using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly ShoppingCartActions _shoppingCart;

        public OrderRepository(BookStoreDbContext bookStoreDbContext, ShoppingCartActions shoppingCart)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            var shoppingCartItems = _shoppingCart.CartItems;
            // Fråga om Order Status  är korrekt??????????

            //  order.OrderStatus = _shoppingCart.GetCartTotal(); ?????

            order.OrderItems = new List<OrderItem>();
            //adding the order with its details ??????

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var OrderItem = new OrderItem
                {
                    Quantity = shoppingCartItem.Quantity,/////<---- Fråga???
                    // vi kan lägga mer grejer sedan

                    BookId = shoppingCartItem.BookId,
                    UnitPrice = shoppingCartItem.Book.UnitPrice,
                };

                order.OrderItems.Add(OrderItem);
            }

            _bookStoreDbContext.Orders.Add(order);

            _bookStoreDbContext.SaveChanges();
        }
    }
}








