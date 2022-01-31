using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PostalNumber { get; set; }

        public string City { get; set; }

        // [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}
