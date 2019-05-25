using GB.Data.DAL;
using GB.Data.Dto;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GB.Data.Repositories
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {

        }

        public UserDto Get(int id)
        {
            try
            {
                var query = _dbContext.Users
                    .Include(u=>u.GameCopies).ThenInclude(gc=>gc.Location)
                    .Include(u=>u.Orders)
                    .Include(u=>u.Role)
                    .Where(x => x.ID == id);
                if (query == null)
                    throw new Exception("User not found");
                UserDto user = query.Select(u=>new UserDto
                {
                    ID = u.ID,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password,
                    BirthDate = u.BirthDate,
                    PhoneNumber = u.PhoneNumber,
                    RoleID = u.RoleID,
                    Role = u.Role.Name,
                    GameCopies = u.GameCopies.Select(g=> new GameCopyDto {
                        ID = g.ID,
                        GameID = g.GameID,
                        Game = new GameDto {
                            ID = g.Game.ID,
                            Name = g.Game.Name
                        },
                        GameCopyStatusID = g.GameCopyStatusID,
                        UserID = g.UserID,
                        LocationID = g.LocationID,
                        Location = new LocationAvailableDto {
                            ID = g.Location.ID,
                            Name = g.Location.Name
                        },
                    }).ToList(),
                }).SingleOrDefault();
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
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password,
                    BirthDate = u.BirthDate,
                    PhoneNumber = u.PhoneNumber,
                    RoleID = u.RoleID,
                    Role = u.Role.Name,
                    GameCopies = u.GameCopies.Select( g=> new GameCopyDto {
                        ID = g.ID,
                        GameID = g.GameID,
                        GameCopyStatusID = g.GameCopyStatusID,
                        UserID = g.UserID,
                        LocationID = g.LocationID
                    }).ToList(),
                    Orders = u.Orders.Select(o => new OrderDto {
                        ID = o.ID,
                        OrderGameCopies = o.OrderGameCopies.Select(ogc => new OrderGameCopyDto
                        {
                            ID = ogc.ID,
                            GameCopyID = ogc.GameCopyID,
                            OrderID = ogc.OrderID,
                            GameID = ogc.GameCopy.GameID,
                            GameName = ogc.GameCopy.Game.Name,
                            LocationID = ogc.GameCopy.LocationID,
                            LocationName = ogc.GameCopy.Location.Name
                    }).ToList(), 
                        CreatedAt = o.CreatedAt,
                        ExpiresAt = o.ExpiresAt,
                        TotalPrice = o.TotalPrice,
                        IsFinishedAt = o.IsFinishedAt
                    }).ToList()
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
            if (u == null)
                throw new Exception(string.Format("User does not exist already"));
            this.Delete(u);
        }

        public User ValidateUser(string username, string password)
        {
            User user = new User();
            user = _dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = new User();
            var query = _dbContext.Users.Include(u=>u.Role).Where(u => u.Username == username);
            user = query.SingleOrDefault();
            var qrole = _dbContext.Roles.Include(r => r.Users).Where(r => r.ID == user.RoleID);
            var role = qrole.SingleOrDefault();
            return user;
        }

        public string[] GetUserRolesByUsername(string username)
        {
            string[] roles = new string[] { };
            roles = _dbContext.Users.Include(x => x.Role).Select(x => x.Role.Name).ToArray();
            return roles;
        }
    }
}
