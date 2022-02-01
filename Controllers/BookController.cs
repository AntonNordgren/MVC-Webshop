using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Data;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookStoreDbContext _bookStoreDbContext;
        // Constructor injection
        public BookController(BookStoreDbContext bookStoreDbContext, IBookRepository bookRepository)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _bookRepository = bookRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the details of the book 'Details View'
        public IActionResult Details(int id)
        {
            Book testBook = _bookRepository.AllBooks.FirstOrDefault(book => book.Id == id);

            return View(testBook);
        }

        //////////////// testing search 

        public ViewResult SearchResult(SearchBookViewModel ViewModel, string SearchText)
        {
            IEnumerable<Book> ListOfBooks = _bookRepository.SearchBookByTitle(SearchText);

            BookLayoutViewModel BooksBySearch = new BookLayoutViewModel("Search Result", 2, ListOfBooks);

            ViewModel.SearchBooksObject = BooksBySearch;


            return View(ViewModel);

            //if (!string.IsNullOrEmpty(SearchText))
            //{
            //    var result = ListOfBooks.Where(s => s.Title.Contains(SearchText));

            //    ///    if(result.FirstOrDefault)
            //    //       return View("~/Views/Book/SearchResultNotFound.cshtml");

            //    return View(new SearhBookViewModel
            //    {
            //        Books = books
            //    });

            //}
            //else
            //    return View("~/Views/Book/SearchResultNotFound.cshtml");




            // IEnumerable<Book> books;
            //books = _bookRepository.SearchBookByTitle(SearchText);
            // if (!string.IsNullOrEmpty(SearchText))
            // {
            //     var result = books.Where(s => s.Title.Contains(SearchText));

            // ///    if(result.FirstOrDefault)
            //  //       return View("~/Views/Book/SearchResultNotFound.cshtml");

            //     return View(new SearhBookViewModel
            //     {
            //         Books = books
            //     });

            // }
            // else
            //     return View("~/Views/Book/SearchResultNotFound.cshtml");
        }

        //public IActionResult Index(CategoryViewModel ViewModel, string Genre)
        //{
        //    List<Book> ListOfBooks = _bookRepository.AllBooks.Where(book => book.Genre.Type == Genre).ToList();

        //    BookLayoutViewModel BooksByCategory = new BookLayoutViewModel(Genre, 2, ListOfBooks);

        //    ViewModel.CategoryBooksObject = BooksByCategory;

        //    // CategoryViewModel ViewModel = new CategoryViewModel();

        //    // ViewModel.CategoryBooksObject= Genre;
        //    // ViewModel.CategoryBooksObject.Books = _bookRepository.AllBooks.Where(book => book.Genre.Type == Genre);

        //    // viewModel.PopularBooks = _bookRepository.AllBooks.Select(x => x);

        //    return View(ViewModel);
        //}



    }
}
