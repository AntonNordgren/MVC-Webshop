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
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public BookAuthor BookAuthors { get; set; }
    }
}
