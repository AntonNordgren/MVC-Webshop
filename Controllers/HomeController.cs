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
        
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<HomeController> _logger;

        // Constructor injection
        public HomeController(IBookRepository bookRepository, ILogger<HomeController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IActionResult Index(HomeViewModel ViewModel)
        {
            List<Book> ListOfBooks = _bookRepository.AllBooks.ToList();

            BookLayoutViewModel PopularBooks = new BookLayoutViewModel("Popular Books", 2, ListOfBooks);

            ViewModel.PopularBooksObject = PopularBooks;

            // ViewBag.List = allBooks;
            // ViewData["Books"] = allBooks;

            return View(ViewModel);
        }

        [Route("/NotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }


        //    return PartialView("_LayoutOptions", layoutoptions);
        //}


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


