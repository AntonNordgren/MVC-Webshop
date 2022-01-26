using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor injection
        public HomeController(IBookRepository bookRepository, ILogger<HomeController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IActionResult Index(HomeViewModel viewModel)
        {
            List<Book> allBooks = _bookRepository.AllBooks.ToList();

            viewModel.PopularBooks = _bookRepository.AllBooks.Select(x => x);

            // Book testBook = _bookRepository.AllBooks.FirstOrDefault(book => book.Id == 1);

            // ViewBag.List = allBooks;
            // ViewData["Books"] = allBooks;

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
