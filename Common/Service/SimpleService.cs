using System;
using System.Linq;
using FluentValidation;
using System.Reflection;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Caspian.Common.Extension;

namespace Caspian.Common.Service
{
    public class SimpleService<TEntity> : CaspianValidator<TEntity>, ISimpleService<TEntity> where TEntity : class
    {
        public SimpleService(IServiceProvider provider)
            :base(provider)
        {
            
        }

        public IQueryable<TEntity> GetAll(TEntity search)
        {
            return Context.Set<TEntity>().Search(search);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity).DetectChanges();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        
        public TEntity SingleOrDefault(int id)
        {
            var type = typeof(TEntity);
            var t = Expression.Parameter(type, "t");
            Expression expr = Expression.Property(t, type.GetPrimaryKey());
            expr = Expression.Equal(expr, Expression.Constant(id));
            expr = Expression.Lambda(expr, t);
            var entity = Context.Set<TEntity>().Where(expr).SingleOrDefault();
            return entity;
        }

        public TEntity Single(int id)
        {
            var old = SingleOrDefault(id);
            return old;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            //Context?.Dispose();
        }
    }
}
