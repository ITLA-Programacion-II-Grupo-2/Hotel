using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Hotel.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(TEntity[] entity);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Remove(TEntity entity);
        void Remove(TEntity[] entities);
        TEntity GetEntity(int entityid);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities();
    }
}