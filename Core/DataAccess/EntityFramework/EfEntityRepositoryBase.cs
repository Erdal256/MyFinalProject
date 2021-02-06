using Core.DataAccsess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //NuGet
        public void Add(TEntity entity)
        {
            // IDısposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity); // referansı yakala
                deleteEntity.State = EntityState.Deleted; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity); // referansı yakala
                updateEntity.State = EntityState.Modified; // eklenecek nesne
                context.SaveChanges(); // ekle
            }
        }
    }
}
