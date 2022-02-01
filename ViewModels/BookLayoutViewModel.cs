using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class BookLayoutViewModel
    {
        public int ColumnSize { get; set; }
        public string CardLayoutTitle { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public BookLayoutViewModel(string CardLayoutTitle, int ColumnSize, IEnumerable<Book> Books)
        {
            this.CardLayoutTitle = CardLayoutTitle;
            this.ColumnSize = ColumnSize;
            this.Books = Books;
        }
    }
}
