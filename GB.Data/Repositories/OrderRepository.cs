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
    public class OrderRepository : DataRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext db) : base(db)
        {

        }

        public Order AddOrder(OrderDto order)
        {
            try
            {
                Order o = new Order
                {
                    CreatedAt = order.CreatedAt,
                    ExpiresAt = order.ExpiresAt,
                    TotalPrice = order.TotalPrice,
                    UserID = order.UserID
                };
                this.Add(o);

                return o;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDto> GetUserOrders( int userID)
        {
            try
            {
                List<OrderDto> orders = new List<OrderDto>();
                var query = _dbContext.Orders.Where(x => x.UserID == userID);
                orders = query.Select(o => new OrderDto {
                    ID = o.ID,
                    UserID = o.UserID,
                    CreatedAt = o.CreatedAt,
                    ExpiresAt = o.ExpiresAt,
                    TotalPrice = o.TotalPrice,
                    IsFinishedAt = o.IsFinishedAt
                }).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto Get( int orderID)
        {
            try
            {
                OrderDto order = new OrderDto();
                var query = _dbContext.Orders
                    .Include(o => o.OrderGameCopies).ThenInclude(og => og.GameCopy).ThenInclude(gc => gc.Game)
                    .Where(o => o.ID == orderID);
                order = query.Select(ord => new OrderDto
                {
                    ID = ord.ID,
                    UserID = ord.UserID,
                    CreatedAt = ord.CreatedAt,
                    ExpiresAt = ord.ExpiresAt,
                    TotalPrice = ord.TotalPrice,
                    IsFinishedAt = ord.IsFinishedAt,
                    OrderGameCopies = ord.OrderGameCopies.Select(o => new OrderGameCopyDto {
                        ID = o.ID,
                        GameCopyID = o.GameCopyID,
                        OrderID = o.OrderID,
                        GameID = o.GameCopy.GameID,
                        GameName = o.GameCopy.Game.Name,
                        LocationID = o.GameCopy.LocationID,
                        LocationName = o.GameCopy.Location.Name
                    }).ToList()
                }).SingleOrDefault();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDto> GetAll()
        {
            try
            {
                List<OrderDto> orders = new List<OrderDto>();
                var query = _dbContext.Orders
                   .Include(o => o.OrderGameCopies).ThenInclude(og => og.GameCopy).ThenInclude(gc => gc.Game)
                   .Include(o => o.User);
                orders = query.Select(o => new OrderDto {
                    ID = o.ID,
                    OrderGameCopies = o.OrderGameCopies.Select(ogc=> new OrderGameCopyDto {
                        ID = ogc.ID,
                        GameCopyID = ogc.GameCopyID,
                        OrderID = ogc.OrderID,
                        GameID = ogc.GameCopy.GameID,
                        GameName = ogc.GameCopy.Game.Name,
                        LocationID = ogc.GameCopy.LocationID,
                        LocationName = ogc.GameCopy.Location.Name
                    }).ToList(),
                    UserID = o.UserID,
                    User = new UserDto {
                        ID = o.ID,
                        Username = o.User.Username,
                        FullName = o.User.FullName,
                        Email = o.User.Email,
                        BirthDate = o.User.BirthDate,
                        PhoneNumber = o.User.PhoneNumber,
                        RoleID = o.User.RoleID,
                        Role = o.User.Role.Name,
                        GameCopies = o.User.GameCopies.ToList(),
                    },
                    CreatedAt = o.CreatedAt,
                    ExpiresAt = o.ExpiresAt,
                    TotalPrice = o.TotalPrice,
                    IsFinishedAt = o.IsFinishedAt
                }).ToList();

                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDto> GetOrdersWithPenalties()
        {
            try
            {
                List<OrderDto> orders = new List<OrderDto>();
                var query = _dbContext.Orders
                   .Include(o => o.OrderGameCopies).ThenInclude(og => og.GameCopy).ThenInclude(gc => gc.Game)
                   .Include(o => o.User)
                   .Where(o=>o.ExpiresAt<DateTime.Now);
                orders = query.Select(o => new OrderDto
                {
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
                    UserID = o.UserID,
                    User = new UserDto
                    {
                        ID = o.ID,
                        Username = o.User.Username,
                        FullName = o.User.FullName,
                        Email = o.User.Email,
                        BirthDate = o.User.BirthDate,
                        PhoneNumber = o.User.PhoneNumber,
                        RoleID = o.User.RoleID,
                        Role = o.User.Role.Name,
                        GameCopies = o.User.GameCopies.ToList(),
                    },
                    CreatedAt = o.CreatedAt,
                    ExpiresAt = o.ExpiresAt,
                    TotalPrice = o.TotalPrice,
                    IsFinishedAt = o.IsFinishedAt
                }).ToList();

                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int FinishOrder(int orderID)
        {
            try
            {
                Order order = _dbContext.Orders.SingleOrDefault(o=>o.ID == orderID);
                order.IsFinishedAt = DateTime.Now;
                this.Update(order);
                return order.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
