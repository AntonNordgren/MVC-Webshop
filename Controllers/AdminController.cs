using Microsoft.AspNetCore.Mvc;
using MVC_Webshop.Models;
using MVC_Webshop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookStoreDbContext _context;
        public AdminController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books =_context.Books.ToList();
            return View(books);
        }
        public IActionResult Books()
        {

            var books = _context.Books.ToList();
            return View(books);
        }
        public IActionResult Bookdetails(int id)
        {
            
            return View(FilledBook(id));
        }
        private Book FilledBook(int id)
        {
            var books = _context.Books.ToList();
            var book = books.First(x => x.Id == id);
            book.Publisher = _context.Publishers.ToList().First(x => x.Id == book.PublisherId);
            book.Genre = _context.Genres.ToList().First(x => x.Id == book.GenreId);
            book.BookAuthors = _context.BookAuthors.ToList().FindAll(x => x.BookId == id);
            for (int i = 0; i < book.BookAuthors.Count(); i++)
            {
                book.BookAuthors[i].Author = _context.Authors.ToList().First(x => x.Id == book.BookAuthors[i].AuthorId);
            }
            return book;
        }
        public IActionResult Bookedit(int id)
        {
            return View(FilledBook(id));
        }
        public IActionResult Bookcreate()
        {
            return View();
        }
    }
}
