using GB.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Web.ViewModels
{
    //!  Klasa CreateUserVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane formularza do dodania nowego zamówienia.
    */
    public class NewOrderVM
    {
        public List<AddToCartDto> OrderGameCopies { get; set; }
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
    }
}