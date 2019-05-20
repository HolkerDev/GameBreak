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
