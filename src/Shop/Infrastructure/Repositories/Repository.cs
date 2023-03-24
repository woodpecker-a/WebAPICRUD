using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _entities;
        protected int CommandTimeout { get; set; }
        public Repository(DbContext dbContext)
        {
            CommandTimeout = 300;
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Edit(TEntity entityToUpdate)
        {
            if(_dbContext.Entry(entityToUpdate).State == EntityState.Detached) _entities.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate.Id).State = EntityState.Modified;
        }

        public void Remove(TKey id)
        {
            var entity = _entities.Find(id);
            Remove(entity);
        }

        public void Remove(TEntity entityToDelete)
        {
            if(_dbContext.Entry(entityToDelete).State == EntityState.Detached) _dbContext.Attach(entityToDelete);
            _entities.Remove(entityToDelete);
        }

        public void Remove(Expression<Func<TEntity, bool>> filter)
        {
            _entities.RemoveRange(_entities.Where(filter));
        }
    }
}
