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

    //!  Serwis ProductionService. 
    /*!
       Serwis, który występuje elementem pośrednim pomiędzy warstwą logiki dostępu do bazy danych w postaci ProductionRepository a  Api w postaci ProductionController.
       Wszystkie metody służą do komunikacji jednej warstwy z drugą oraz transferu danych pomiędzy nimi. 
    */
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
