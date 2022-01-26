using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace MVC_Webshop.Data
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

      //  [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

       // [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }

       // [Required(ErrorMessage = "Please enter your postal number")]
        [Display(Name = "Postal number")]
        [StringLength(5, MinimumLength = 5)]
        public string PostalNumber { get; set; }

        //[Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }

        // [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; }

      //  public bool Admin { get; set; }

        //[Required(ErrorMessage = "Please enter your phone number")]
        //[StringLength(25)]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone number")]
        //public string PhoneNumber { get; set; }

    }
}
