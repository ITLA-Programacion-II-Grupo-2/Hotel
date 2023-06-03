using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Hotel.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Save(TEntity[] entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetEntity(int entityid);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities();
    }
}
