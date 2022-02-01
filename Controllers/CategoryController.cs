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

        public IActionResult Index(CategoryViewModel ViewModel, string Genre)
        {
            List<Book> ListOfBooks = _bookRepository.AllBooks.Where(book => book.Genre.Type == Genre).ToList();

            BookLayoutViewModel BooksByCategory = new BookLayoutViewModel(Genre, 2, ListOfBooks);

            ViewModel.CategoryBooksObject = BooksByCategory;

            // CategoryViewModel ViewModel = new CategoryViewModel();

            // ViewModel.CategoryBooksObject= Genre;
            // ViewModel.CategoryBooksObject.Books = _bookRepository.AllBooks.Where(book => book.Genre.Type == Genre);

            // viewModel.PopularBooks = _bookRepository.AllBooks.Select(x => x);

            return View(ViewModel);
        }

        //public IActionResult Index(HomeViewModel ViewModel)
        //{
        //    List<Book> ListOfBooks = _bookRepository.AllBooks.ToList();

        //    BookLayoutViewModel PopularBooks = new BookLayoutViewModel("Popular Books", 2, ListOfBooks);

        //    ViewModel.PopularBooksObject = PopularBooks;

        //    return View(ViewModel);
        //}
    }
}
