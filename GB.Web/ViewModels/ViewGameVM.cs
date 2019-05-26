using GB.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GB.Web.ViewModels
{
    //!  Klasa ViewGameVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane do wyświetlenia wybranej gry.
    */
    public class ViewGameVM
    {
        public GameDto Game { get; set; }
        public List<SelectListItem> LocationsSelect { get; set; }

        public ViewGameVM CreateVM( GameDto game)
        {
            Game = game;
            LocationsSelect = game.LocationsWithGameCopiesAvailable.Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.ID.ToString()
            }).ToList();
            return this;
        }
    }
}