using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using MVC_Webshop.ViewModels;
using MVC_Webshop.Data;
using Rotativa;

namespace MVC_Webshop.Controllers
{
    public class PdfsController : Controller
    {
        BookStoreDbContext _context;
        public PdfsController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string id)
        {
            OrderViewModel model = new OrderViewModel();
            model.Order = _context.Orders.First(x => x.Id.ToString() == id);
            model.OrderItems = _context.OrderItems.ToList().FindAll(x => x.OrderId == model.Order.Id);
            model.Books = _context.Books.ToList();
            model.Users = _context.Users.ToList();
            var order = _context.Orders.First(x => x.Id == int.Parse(id));
            if (order.TotalCost != Total(model.Order.Id))
            {
                order.TotalCost = Total(model.Order.Id);
                _context.SaveChanges();
            }
           
            return new Rotativa.AspNetCore.ViewAsPdf(model);
        }

        private decimal Total(int orderid)
        {
            decimal total = 0;
            foreach (var item in _context.OrderItems)
            {
                if (item.OrderId == orderid)
                {
                    total += item.UnitPrice * item.Quantity;
                }
            }
            return total;
            
        }
    }
}
