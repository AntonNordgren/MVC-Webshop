using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class BookRepository : IBookRepository
    {
        // To get access to BookStoreDbContext in BookRepository
        private readonly BookStoreDbContext _bookStoreDbContext;
        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;


        }

        // example to get All Books with their genre
        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _bookStoreDbContext.Books.Include(c => c.Genre);
               
            }
        }

        // Get the Book by passing book id
        public Book GetBookById(int bookId)
        {
            return _bookStoreDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        // search for books by book title
      
        public IEnumerable<Book> SearchBookByTitle(string SearchText)
        {
            //if(!string.IsNullOrEmpty (bookTitle) )
                 
            return _bookStoreDbContext.Books.Where(re => re.Title.Contains(SearchText) ||
                                                         re.Isbn.Contains(SearchText));

        }


    }
}
