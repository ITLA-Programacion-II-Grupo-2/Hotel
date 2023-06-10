using Hotel.Domain.Repository;
using Hotel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hotel.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private readonly DbSet<TEntity> myDbSet;

        public BaseRepository(HotelContext context)
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbSet.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
            return this.myDbSet.ToList();
        }
        public virtual TEntity GetEntity(int id)
        {
            return this.myDbSet.Find(id);
        }
        public virtual void Remove(TEntity entity)
        {
            this.myDbSet.Remove(entity);

        }
        public virtual void Remove(TEntity[] entities)
        {
            this.myDbSet.RemoveRange(entities);
        }
        public virtual void Add(TEntity entity)
        {
            this.myDbSet.Add(entity);
        }
        public virtual void Add(TEntity[] entities)
        {
            this.myDbSet.AddRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }
        public virtual void Update(TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}