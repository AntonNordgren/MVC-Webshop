using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa;
using MVC_Webshop.ViewModels;
using MVC_Webshop.Data;

namespace MVC_Webshop.Controllers
{
    public class PdfsController : Controller
    {
        BookStoreDbContext _context;
        public PdfsController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            OrderViewModel vm = new OrderViewModel();
            vm.Books = _context.Books.ToList();
            vm.OrderItems = _context.OrderItems.ToList();
            
            return View(vm);
        }
    }
}
