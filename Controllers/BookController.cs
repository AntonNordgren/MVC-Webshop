﻿using Microsoft.AspNetCore.Mvc;
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
        
        public ViewResult SearchResult(string SearchText)
        {

            IEnumerable<Book> books;

           books = _bookRepository.SearchBookByTitle("wok");
            //if (!string.IsNullOrEmpty(SearchText))
            //{
            //    var result = books.Where(s => s.Title.Contains(SearchText));
              
            //}
            //else
            //{

            //}
            // searhBookViewModel.SearchBooks = _bookRepository.AllBooks.Select(x => x);

            // Book testBook = _bookRepository.AllBooks.FirstOrDefault(book => book.Id == 1);

            // ViewBag.List = allBooks;
            // ViewData["Books"] = allBooks;

            return View(new SearhBookViewModel
            {
                Books = books
            }); 
    }
        
       

    }
}
