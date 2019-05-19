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
    public class ProductionRepository : DataRepository<Production>, IProductionRepository
    {
        public ProductionRepository(ApplicationContext db) : base(db)
        {

        }

        public List<ProductionDto> GetAll()
        {
            try
            {
                List<ProductionDto> productions = new List<ProductionDto>();
                var query = _dbContext.Productions;
                productions = query.Select(u => new ProductionDto
                {
                    ID = u.ID,
                    Name = u.Name

                }).ToList();

                return productions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
