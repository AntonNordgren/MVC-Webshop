using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IBookRepository _bookRepository;

        // Constructor injection
        public CategoryController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index(string Genre, CategoryViewModel ViewModel)
        {
            // CategoryViewModel ViewModel = new CategoryViewModel();

            ViewModel.Category = Genre;
            ViewModel.BooksByCategory = _bookRepository.AllBooks.Where(book => book.Genre.Type == Genre);

            // viewModel.PopularBooks = _bookRepository.AllBooks.Select(x => x);

            return View(ViewModel);
        }
    }
}
