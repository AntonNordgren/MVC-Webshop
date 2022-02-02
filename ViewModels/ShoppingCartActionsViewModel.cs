using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.ViewModels
{
    public class ShoppingCartActionsViewModel
    {
        public ShoppingCartActions ShoppingCartActions { get; set; }
        public decimal CartTotal { get; set; }
       
    }
}
