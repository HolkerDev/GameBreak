using GB.Data.DAL;
using GB.Entities.Models;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Repositories
{
    //!  Repozytorium ProductionGamePlatformRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla tabeli ProductionGamePlatform.
    */
    public class ProductionGamePlatformRepository : DataRepository<ProductionGamePlatform>, IProductionGamePlatformRepository
    {
        public ProductionGamePlatformRepository(ApplicationContext db) : base(db)
        {

        }
    }
}
