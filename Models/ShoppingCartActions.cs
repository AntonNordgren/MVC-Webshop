using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class ShoppingCartActions
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public ShoppingCartActions(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        //User visits the site,
        //program will check for any active session containing a cart Id,
        //if not create a new one
        //then create an instance of shopping cart passing in that cart Id
        public static ShoppingCartActions GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<BookStoreDbContext>();
            //Global Unique Identifier GUID
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCartActions(context) { CartId = cartId };
        }


        // update cart 
        public void UpdateCart(Book book, int quantity)
        {
            var cartItem = _bookStoreDbContext.CartItems.SingleOrDefault(
                         i => i.Book.Id == book.Id && i.CartId == CartId);
      
                cartItem.Quantity = quantity;
            
            _bookStoreDbContext.SaveChanges();

        }

        //Add books to the cart
        public void AddToCart(Book book, int quantity)
        {
            var cartItem = _bookStoreDbContext.CartItems.SingleOrDefault(
                        i => i.Book.Id == book.Id && i.CartId == CartId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Book = book,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _bookStoreDbContext.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _bookStoreDbContext.SaveChanges();

        }

        //Remove book from cart
        public int RemoveFromCart(Book book)
        {
            var itemInCart = 
        _bookStoreDbContext.CartItems.SingleOrDefault(
            s => s.Book.Id == book.Id && s.CartId == CartId);

            var amount = 0;

            if (itemInCart != null)
            {
                if (itemInCart.Quantity > 1)
                {
                    itemInCart.Quantity--;
                    amount = itemInCart.Quantity;
                }
                else
                {
                    _bookStoreDbContext.CartItems.Remove(itemInCart);
                }
            }
            _bookStoreDbContext.SaveChanges();
            return amount;
        }

        // Get All the cart items
        public List<CartItem> GetCartItems()
        {

            return CartItems ??
                  (CartItems = _bookStoreDbContext.CartItems
                  .Where(ci => ci.CartId == CartId)
                  .Include(b => b.Book)
                  .ToList());
        }

        // Empty the shopping cart
        public void CleanCart()
        {
            var cartItems = _bookStoreDbContext.CartItems
             .Where(c => c.CartId == CartId);

            _bookStoreDbContext.CartItems.RemoveRange(cartItems);

            _bookStoreDbContext.SaveChanges();

        }

        //Get the total price of the books in the cart
        public decimal GetCartTotal()
        {
            var totalPrice = _bookStoreDbContext.CartItems.Where(c => c.CartId == CartId)
                .Select(t => t.Book.UnitPrice * t.Quantity).Sum();
            return totalPrice;
        }

    }
}
