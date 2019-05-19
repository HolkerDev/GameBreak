using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IUserService
    {
        User Get(int id);
        User AddUser(UserDto user);
        List<UserDto> GetAll();
        void Remove(int id);
    }

    public class UserService : IUserService
    {

        private readonly UserRepository userRepo;

        public UserService( UserRepository userRepository)
        {
            userRepo = userRepository;
        }

        public User Get(int id)
        {
            User user = userRepo.Get(id);
            return user;
        }

        public User AddUser(UserDto user)
        {
            User u = userRepo.AddUser(user);
            return u;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> users = userRepo.GetAll();
            return users;
        }

        public void Remove (int id)
        {
            userRepo.Remove(id);
        }
    }
}
