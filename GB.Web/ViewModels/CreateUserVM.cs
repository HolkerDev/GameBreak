using GB.Data.Dto;
using GB.Entities.Models;
using GB.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GB.Web.ViewModels
{
    //!  Klasa CreateUserVM. 
    /*!
       Klasa typu ViewModel, reprezentująca dane do wyświetlenia formularza dodania nowego użytkownika lub edytowania isntejącego, zawiera dane Użytkownika oraz dostępnych Roli.
    */
    public class CreateUserVM
    {
        public CreateUser User { get; set; }

        public List<RoleDto> Roles { get; set; }

        public List<SelectListItem> SelectRole { get; set; }

        public List<SelectListItem> MakeSelectList(List<RoleDto> roles) {
            foreach(RoleDto role in roles)
            {
                SelectRole.Add(new SelectListItem() { Text = role.Name, Value = role.ID.ToString() });
            }
            return SelectRole;
        }
    }
}
