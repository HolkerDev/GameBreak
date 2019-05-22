using GB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Services
{
    public interface IProductionGamePlatformService
    {

    }

    public class ProductionGamePlatformService : IProductionGamePlatformService
    {
        private ProductionGamePlatformRepository productionGamePlatformRepository;

        public ProductionGamePlatformService(ProductionGamePlatformRepository productionGamePlatformRepository)
        {
            this.productionGamePlatformRepository = productionGamePlatformRepository;
        }
    }
}
