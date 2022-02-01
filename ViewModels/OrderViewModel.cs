using MVC_Webshop.Data;
using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
