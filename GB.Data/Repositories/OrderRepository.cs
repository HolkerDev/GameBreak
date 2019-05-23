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
    }
}
