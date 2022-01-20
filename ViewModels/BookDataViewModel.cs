using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class BookDataViewModel
    {
        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public BookAuthor BookAuthor { get; set; }
    }
}
