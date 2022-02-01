using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVC_Webshop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    [BindNever]
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal  TotalCost { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }


        // Navigation properties
        public List<OrderItem> OrderItems { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
