using GB.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Web.ViewModels
{
    //!  Klasa ViewOrdersVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane do wyświetlenia listy zamówień.
    */
    public class ViewOrdersVM
    {
        public List<OrderDto> Orders { get; set; }
    }
}