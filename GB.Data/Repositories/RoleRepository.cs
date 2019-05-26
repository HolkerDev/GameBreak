using GB.Data.DAL;
using GB.Data.Dto;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Repositories
{
    //!  Repozytorium RoleRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli Role.
    */
    public class RoleRepository : DataRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium GetAll. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy roli.
        */
        public List<RoleDto> GetAll()
        {
            try
            {
                List<RoleDto> roles = new List<RoleDto>();
                var query = _dbContext.Roles;
                roles = query.Select(u => new RoleDto
                {
                   ID = u.ID,
                   Name = u.Name
                }).ToList();

                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
