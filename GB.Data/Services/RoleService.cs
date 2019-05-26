using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IRoleService
    {
        Role Get(int id);
        List<RoleDto> GetAll();
    }

    //!  Serwis RoleService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci RoleRepository a  Api w postaci RoleController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class RoleService : IRoleService
    {

        private readonly RoleRepository roleRepo;

        public RoleService(RoleRepository roleRepository)
        {
            roleRepo = roleRepository;
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoleDto> GetAll()
        {
            List<RoleDto> roles = roleRepo.GetAll();
            return roles;
        }
    }
}
