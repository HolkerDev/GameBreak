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

    //!  Serwis ProductionGamePlatformService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci ProductionGamePlatformRepository a  Api w postaci OrderGameCopyController.
    */
    public class ProductionGamePlatformService : IProductionGamePlatformService
    {
        private ProductionGamePlatformRepository productionGamePlatformRepository;

        public ProductionGamePlatformService(ProductionGamePlatformRepository productionGamePlatformRepository)
        {
            this.productionGamePlatformRepository = productionGamePlatformRepository;
        }
    }
}
