using GB.Data.DAL;
using GB.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.Repositories
{
    //!  Repozytorium DataRepository. 
    /*!
       Klasa, która zawiera wszystkie elementy logiki dostępu do danych dla podstawowych działan Add, Update, Delete oraz SaveChanges.
    */
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected readonly ApplicationContext _dbContext;

        private DbSet<T> SetInternal => _dbContext.Set<T>();
        public IQueryable<T> Set => SetInternal;

        public DataRepository(ApplicationContext db)
        {
            _dbContext = db;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public T AddWithoutSave(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteWithoutSave(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void UpdateWithoutSave(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
