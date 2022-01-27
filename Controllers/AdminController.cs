using Microsoft.AspNetCore.Authorization;
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
    [Authorize (Roles = "Admin")]
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
            if (!(_context.Books.Any(x => x.Id == id)))
            {
               
                return View("NotFoundBook");
            }
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
            if (!(_context.Books.Any(x=>x.Id==id))) { Response.StatusCode = 404;
                return View("NotFoundBook");
            }
            BookDataViewModel vm = new BookDataViewModel();
            vm.Book = FilledBook(id);
            vm.Authors = _context.Authors.ToList();
            vm.Genres = _context.Genres.ToList();
            vm.Publishers = _context.Publishers.ToList();
            
            return View(vm);
        }
        public IActionResult Bookcreate()
        {
            
            BookDataViewModel vm = new BookDataViewModel();
            
            vm.Authors = _context.Authors.ToList();
            vm.Genres = _context.Genres.ToList();
            vm.Publishers = _context.Publishers.ToList();

            return View(vm);
        }
        [HttpPost]
        public IActionResult AddBook(
            string id,
            string title,
            string isbn,
            string genreid,
            string publisherid,
            string publishdate,
            string language,
            string[] authorids,
            string unitprice,
            string quantity,
            string imageurl,
            string totalpages,
            string description)
        {
            //make sure that no value is null
            title = title == null ? "" : title;
            isbn = isbn == null ? "" : isbn;
            publishdate = publishdate == null ? "" : publishdate;
            language = language == null ? "" : language;
            unitprice = unitprice == null ? "" : unitprice;
            quantity = quantity == null ? "" : quantity;
            imageurl = imageurl == null ? "" : imageurl;
            description = description == null ? "" : description;
            totalpages = totalpages == null ? "" : totalpages;

            bool valid = true;
            if (title.Length < 1 || title.Length > 1000)
            {
                ViewBag.TITLE = "book needs a title with less that 1000 characters";
                valid = false;
            }
           
            if (isbn.Length != 13)
            {
                ViewBag.ISBN = "ISBN need to be 13 characters";
                valid = false;
            }
            
            if (unitprice == "" || decimal.Parse(unitprice) < 0)
            {
                ViewBag.UNITPRICE = "Unitprice needs to be a positive number";
                valid = false;
            }
            
            if (quantity == "" || int.Parse(quantity) < 0)
            {
                ViewBag.QUANTITY = "Quantity needs to be a positive number";
                valid = false;
            }
            
            if (totalpages == "" || int.Parse(totalpages) < 0)
            {
                ViewBag.TOTALPAGES = "pages needs to be a positive number";
                valid = false;
            }
            
            if (publishdate == "")
            {
                ViewBag.PUBLISHDATE = "Please enter a date for publishing";
                valid = false;
            }
            if (valid)
            {
                
                _context.Books.Add(new Book
                {
                    GenreId = int.Parse(genreid),
                    PublisherId = int.Parse(publisherid),
                    Language = language,
                    Description = description,
                    ImageUrl = imageurl,
                    PublisherDate = DateTime.Parse(publishdate),
                    UnitPrice = decimal.Parse(unitprice),
                    Quantity=int.Parse(quantity),
                    TotalPage=int.Parse(totalpages),
                    Isbn=isbn,
                    Title=title

                }) ;
                _context.SaveChanges();
                int newid = _context.Books.Max(u => u.Id);

                
                for(int i=0; i<authorids.Length; i++)
                {
                    _context.BookAuthors.Add(new BookAuthor { AuthorId=int.Parse(authorids[i]),BookId=newid});
                }
                _context.SaveChanges();
                var books = _context.Books.ToList();
                return View("Books", books);
            }
            else
            {
                BookDataViewModel vm = new BookDataViewModel();

                vm.Authors = _context.Authors.ToList();
                vm.Genres = _context.Genres.ToList();
                vm.Publishers = _context.Publishers.ToList();
                return View("BookCreate",vm);
            }

            
        }
        
        [HttpPost]
        public IActionResult DeleteBook(string id)
        {

            _context.BookAuthors.RemoveRange(_context.BookAuthors.Where(x => x.BookId == int.Parse(id)));
            _context.SaveChanges();
            _context.Books.RemoveRange(_context.Books.Where(x => x.Id == int.Parse(id)));
            _context.SaveChanges();

            var books = _context.Books.ToList();
            return View("Books",books);
        }

        [HttpPost]
        public IActionResult EditBook(
            string id,
            string title,
            string isbn,
            string genreid,
            string publisherid,
            string publishdate,
            string language,
            string[] authorids,
            string unitprice,
            string quantity,
            string imageurl,
            string totalpages,
            string description)
        {
            //make sure that no value is null
            title = title == null ? "" : title;
            isbn = isbn == null ? "" : isbn;
            publishdate = publishdate == null ? "" : publishdate;
            language = language == null ? "" : language;
            unitprice = unitprice == null ? "" : unitprice;
            quantity = quantity == null ? "" : quantity;
            imageurl = imageurl == null ? "" : imageurl;
            description = description == null ? "" : description;
            totalpages = totalpages == null ? "" : totalpages;

            var book = _context.Books.First(a => a.Id == int.Parse(id));

            if (title.Length<1 || title.Length > 1000)
            {
                ViewBag.TITLE = "book needs a title with less that 1000 characters";
            }
            else{book.Title = title;}
            if (isbn.Length != 13)
            {
                ViewBag.ISBN = "ISBN need to be 13 characters";
            }
            else
            {
                book.Isbn = isbn;
            }
            if(unitprice=="" || decimal.Parse(unitprice) < 0)
            {
                ViewBag.UNITPRICE = "Unitprice needs to be a positive number";
            }
            else { book.UnitPrice = decimal.Parse(unitprice); }
            if (quantity == "" || int.Parse(quantity) < 0)
            {
                ViewBag.QUANTITY = "Quantity needs to be a positive number";
            }
            else { book.Quantity = int.Parse(quantity); }
            if (totalpages == "" || int.Parse(totalpages) < 0)
            {
                ViewBag.TOTALPAGES = "pages needs to be a positive number";
            }
            else { book.TotalPage = int.Parse(totalpages); }
            if (publishdate == "")
            {
                ViewBag.PUBLISHDATE = "Please enter a date for publishing";
            }

            else { book.PublisherDate= DateTime.Parse(publishdate); }
            
            book.GenreId = int.Parse(genreid);
            book.PublisherId = int.Parse(publisherid);
            book.Language = language;
            book.Description = description;
            book.ImageUrl = imageurl;


            _context.BookAuthors.RemoveRange(_context.BookAuthors.Where(x => x.BookId == int.Parse(id)));
            for (int i = 0; i < authorids.Length; i++) {
                _context.BookAuthors.Add(new BookAuthor
                {
                    AuthorId = int.Parse(authorids[i]),
                    BookId = int.Parse(id)
                });
            }
            _context.SaveChanges();
            //create new viewmodel to send to editpage
            BookDataViewModel vm = new BookDataViewModel();
            vm.Book = FilledBook(int.Parse(id));
            vm.Authors = _context.Authors.ToList();
            vm.Genres = _context.Genres.ToList();
            vm.Publishers = _context.Publishers.ToList();
            
            return View("Bookedit" , vm);
        }

        public IActionResult PublisherEdit()
        {
            BookDataViewModel vm = new BookDataViewModel();
            vm.Publishers = _context.Publishers;
            return View(vm);
        }
        public IActionResult GenreEdit()
        {
            BookDataViewModel vm=new BookDataViewModel();
            vm.Genres = _context.Genres;
            return View(vm);
        }
        public IActionResult AuthorEdit()
        {
            BookDataViewModel vm = new BookDataViewModel();
            vm.Authors = _context.Authors;
            return View(vm);
        }
        //genres
        [HttpPost]
        public IActionResult DeleteGenre(string id)
        {
            BookDataViewModel vm = new BookDataViewModel();
            vm.Genres = _context.Genres;
            vm.Books = _context.Books;
            var genre = new Genre() { Id = int.Parse(id) };
            if (vm.Books.Any(p => p.GenreId == int.Parse(id)))
            {
                ViewBag.ErrorMess = "Could not delete, make sure there are no books with the genre you are attempting to delete first";
            }
            else
            {
                _context.Genres.Attach(genre);
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            vm.Genres = _context.Genres.ToList();
            return View("GenreEdit", vm);
        }
        [HttpPost]
        public IActionResult EditGenre(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                var genre = _context.Genres.First(a => a.Id == int.Parse(id));
                genre.Type = name;
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Genres = _context.Genres.ToList();
            return View("GenreEdit", vm);
        }
        [HttpPost]
        public IActionResult AddGenre(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                _context.Genres.Add(new Genre()
                {
                    Type = name
                });
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Genres = _context.Genres.ToList();

            return View("GenreEdit", vm);
        }


        //Publishers
        [HttpPost]
        public IActionResult DeletePublisher(string id)
        {
            BookDataViewModel vm = new BookDataViewModel();
            vm.Publishers = _context.Publishers;
            vm.Books = _context.Books;
            var publisher = new Publisher() { Id = int.Parse(id) };
            if (vm.Books.Any(p => p.PublisherId == int.Parse(id)))
            {
                ViewBag.ErrorMess = "Could not delete, make sure there are no books with the publisher you are attempting to delete first";
            }
            else
            {
                _context.Publishers.Attach(publisher);
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
            vm.Publishers = _context.Publishers.ToList();
            return View("PublisherEdit", vm);
        }
        [HttpPost]
        public IActionResult EditPublisher(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                var publisher = _context.Publishers.First(a => a.Id == int.Parse(id));
                publisher.Name = name;
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Publishers = _context.Publishers.ToList();
            return View("PublisherEdit", vm);
        }
        [HttpPost]
        public IActionResult AddPublisher(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                _context.Publishers.Add(new Publisher()
                {
                    Name = name
                });
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Publishers = _context.Publishers.ToList();

            return View("PublisherEdit", vm);
        }
        //Authors
        [HttpPost]
        public IActionResult DeleteAuthor(string id)
        {
            BookDataViewModel vm = new BookDataViewModel();
            vm.Publishers = _context.Publishers;
            
            vm.BookAuthors = _context.BookAuthors;
            var author = new Author() { Id = int.Parse(id) };
            if (vm.BookAuthors.Any(p => p.AuthorId == int.Parse(id)))
            {
                ViewBag.ErrorMess = "Could not delete, make sure there are no books with the Author you are attempting to delete first";
            }
            else
            {
                _context.Authors.Attach(author);
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            vm.Authors = _context.Authors.ToList();
            return View("AuthorEdit", vm);
        }
        [HttpPost]
        public IActionResult EditAuthor(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                var author = _context.Authors.First(a => a.Id == int.Parse(id));
               author.FullName = name;
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Authors = _context.Authors.ToList();
            return View("AuthorEdit", vm);
        }
        [HttpPost]
        public IActionResult AddAuthor(string id, string name)
        {
            if (name == null)
            {
                name = "";
            }
            BookDataViewModel vm = new BookDataViewModel();
            if (name.Length > 0)
            {
                _context.Authors.Add(new Author()
                {
                    FullName = name
                }) ;
                _context.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMess = "Please fill in the field";
            }
            vm.Authors = _context.Authors.ToList();

            return View("AuthorEdit", vm);
        }

    }
}
