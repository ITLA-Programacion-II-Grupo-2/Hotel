using Hotel.Domain.Repository;
using Hotel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hotel.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private readonly DbSet<TEntity> myDbset;

        public BaseRepository(HotelContext context)
        {
            this.context = context;
            this.myDbset = this.context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            if (this.myDbset.Where(filter).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
             return myDbset.ToList();
        }

        public virtual TEntity GetEntity(int entityid)
        {
            return myDbset.Find(entityid);
        }

        public virtual void Remove(TEntity entity)
        {
            this.myDbset.Remove(entity);
        }

        public virtual void Add(TEntity entity)
        {
          this.myDbset.Add(entity);
            
        }

        public virtual void Add(TEntity[] entities)
        {
           this.myDbset.AddRange(entities);

        }

        public virtual void Update(TEntity entity)
        {
            this.myDbset.Update(entity);

        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}