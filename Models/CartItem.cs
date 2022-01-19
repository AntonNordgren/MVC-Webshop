using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    public class CartItem
    {
        [Key]
        //Counter
        public int Id { get; set; }

        //CartId specifies the ID of the user that is associated with the item to purchase 'GUID'
        public string CartId { get; set; }
        
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
