﻿using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the details of the book 'Details View'
        public IActionResult Details(int id)
        {
            
                            
            var Book = _bookRepository.GetBookById(id);
            if (Book == null)
                return NotFound();
            return View(Book);
        }
    }
}
