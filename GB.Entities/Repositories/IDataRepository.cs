using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Entities.Repositories
{
    public interface IDataRepository<T>
    {
        //Set
        IQueryable<T> Set { get; }

        //Add
        T Add(T entity);
        T AddWithoutSave(T entity);

        //Update
        void Update(T entity);
        void UpdateWithoutSave(T entity);

        //Delete
        void Delete(T entity);
        void DeleteWithoutSave(T entity);

        //Save changes
        void SaveChanges();
    }
}
