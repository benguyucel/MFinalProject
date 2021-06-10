using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TContext, TEnttiy> : IEntityRepository<TEnttiy>
        where TEnttiy : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEnttiy entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEnttiy entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEnttiy Get(Expression<Func<TEnttiy, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEnttiy>().SingleOrDefault(filter);
            }
        }

        public List<TEnttiy> GetAll(Expression<Func<TEnttiy, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEnttiy>().ToList() :
                    context.Set<TEnttiy>().Where(filter).ToList();
            }
        }

        public void Update(TEnttiy entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
