using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.Tools.Interfaces
{
    public interface IRepository <T, TEntity > where TEntity : class, IEntity<T>
    {
        //Create
        T Insert(TEntity entity);
        // Read
        IEnumerable<TEntity> GetAll();
        TEntity GetById(T id);
        // Update
        bool Update(TEntity entity);
        // Delete
        bool Delete(T id);
    }
}
