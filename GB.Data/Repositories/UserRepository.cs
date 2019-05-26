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
    //!  Repozytorium UserRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli User.
    */
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {

        }

        //!  Metoda repozytorium Get. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania konkretnego użytkownika.
        */
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
                    Orders = u.Orders.Select(o => new OrderDto {
                        ID = o.ID,
                        CreatedAt = o.CreatedAt,
                        ExpiresAt = o.ExpiresAt,
                        IsFinishedAt = o.IsFinishedAt,
                        TotalPrice = o.TotalPrice
                    }).ToList()
                }).SingleOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //!  Metoda repozytorium AddUser. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu dodania nowego użytkownika w bazie danych.
        */
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

        //!  Metoda repozytorium GetAll. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy użytkowników.
        */
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

        //!  Metoda repozytorium Remove. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu usunięcia użytkownika z bazy danych.
        */
        public void Remove(int id)
        {
            User u = _dbContext.Users.SingleOrDefault(x => x.ID == id);
            if (u == null)
                throw new Exception(string.Format("User does not exist already"));
            this.Delete(u);
        }

        //!  Metoda repozytorium ValidateUser. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu walidacji użytkownika.
        */
        public User ValidateUser(string username, string password)
        {
            User user = new User();
            user = _dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        //!  Metoda repozytorium GetUserByUsername. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania użytkownika z wskazanym polem username.
        */
        public User GetUserByUsername(string username)
        {
            User user = new User();
            var query = _dbContext.Users.Include(u=>u.Role).Where(u => u.Username == username);
            user = query.SingleOrDefault();
            var qrole = _dbContext.Roles.Include(r => r.Users).Where(r => r.ID == user.RoleID);
            var role = qrole.SingleOrDefault();
            return user;
        }

        //!  Metoda repozytorium GetUserRolesByUsername. 
        /*!
           Zawiera elementy logiki dostępu do danych w celu pobrania listy roli użytkownika.
        */
        public string[] GetUserRolesByUsername(string username)
        {
            string[] roles = new string[] { };
            roles = _dbContext.Users.Include(x => x.Role).Select(x => x.Role.Name).ToArray();
            return roles;
        }
    }
}
