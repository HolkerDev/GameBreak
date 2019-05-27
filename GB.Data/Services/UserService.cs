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
        UserDto Get(int id);
        User AddUser(UserDto user);
        List<UserDto> GetAll();
        void Remove(int id);
    }

    //!  Serwis UserService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci UserRepository a  Api w postaci UserController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
    public class UserService : IUserService
    {

        private readonly UserRepository userRepo;

        public UserService( UserRepository userRepository)
        {
            userRepo = userRepository;
        }

        public UserDto Get(int id)
        {
            UserDto user = userRepo.Get(id);
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
