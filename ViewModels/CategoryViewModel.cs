using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class CategoryViewModel
    {
        //public string Category { get; set; }
        //public IEnumerable<Book> BooksByCategory { get; set; }

        public BookLayoutViewModel CategoryBooksObject { get; set; }
    }
}
