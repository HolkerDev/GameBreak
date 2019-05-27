using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Web.ViewModels
{
    //!  Klasa CartVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane do wyświetlenia koszyka.
    */
    public class CartVM
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}