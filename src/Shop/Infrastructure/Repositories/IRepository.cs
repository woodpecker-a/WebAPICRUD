using Infrastructure.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
    }
}