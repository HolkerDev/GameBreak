using GB.Data.DAL;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GB.Data.Dto;

namespace GB.Data.Repositories
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {

        }

        public User Get(int id)
        {
            try
            {
                User user = _dbContext.Users.SingleOrDefault(x => x.ID == id);
                if (user == null)
                    throw new Exception("User not found");
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User AddUser(UserDto user)
        {
            try
            {
                var userExists =  _dbContext.Users.SingleOrDefault(x => x.Email == user.Email);
                if (userExists != null)
                    throw new Exception(string.Format("User with email {0} already exists", user.Email));
                User u = new User
                {
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    FullName = user.FullName,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    Username = user.Username,
                    RoleID = user.RoleID
                };
                this.Add(u);
                return u;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<UserDto> GetAll()
        {
            try
            {
                List<UserDto> users = new List<UserDto>();
                var query = _dbContext.Users.Include(q => q.Role).Include(x=>x.GameCopies).Include(x=>x.Orders);
                users = query.Select(u => new UserDto
                {
                    ID = u.ID,
                    Username = u.Username,
                    FullName = u.FullName,
                    Email = u.Email,
                    Password = u.Password,
                    BirthDate = u.BirthDate,
                    PhoneNumber = u.PhoneNumber,
                    RoleID = u.RoleID,
                    Role = u.Role.Name,
                    GameCopies = u.GameCopies.ToList(),
                    Orders = u.Orders.ToList()
                }).ToList();

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void Remove(int id)
        {
            User u = _dbContext.Users.SingleOrDefault(x => x.ID == id);
            if(u==null)
                throw new Exception(string.Format("User does not exist already"));
            this.Delete(u);
        }
    }
}
