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
        private readonly HotelContext hotel;
        private readonly DbSet<TEntity> entities;

        public BaseRepository(HotelContext hotel)
        {
            this.hotel = hotel;
            this.entities = this.hotel.Set<TEntity>();
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            if (this.entities.Where(filter).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
