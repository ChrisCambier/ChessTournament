using ChessTournament.DL.Interfaces;
using ChessTournament.IL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Repository
{
    public class BaseRepository<T, TEntity> : IRepository<T, TEntity> where TEntity : class, IEntity<T>
    {
        private readonly TournamentDbContext _dbContext;
        public BaseRepository(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(T id)
        {
            var found = _dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
            if (found == null)
            {
                throw new Exception("Not Found ! :(");
            }
            return found;
        }

        public T Insert(TEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public bool Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(T id)
        {
            var found = GetById(id);
            _dbContext.Remove(found);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
