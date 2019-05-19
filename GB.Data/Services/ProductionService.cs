using GB.Data.Dto;
using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IProductionService
    {

    }

    public class ProductionService : IProductionService
    {
        private readonly ProductionRepository productionRepo;

        public ProductionService(ProductionRepository productionRepository)
        {
            productionRepo = productionRepository;
        }

        public List<ProductionDto> GetAll()
        {
            List<ProductionDto> productions = productionRepo.GetAll();
            return productions;
        }
    }
}
