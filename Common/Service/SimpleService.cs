using System;
using System.Linq;
using FluentValidation;
using System.Reflection;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Caspian.Common.Extension;
using Microsoft.EntityFrameworkCore;

namespace Caspian.Common.Service
{
    public class SimpleService<TEntity> : CaspianValidator<TEntity>, ISimpleService<TEntity> where TEntity : class
    {
        public virtual IQueryable<TEntity> GetAll(TEntity search = null)
        {
            return Context.Set<TEntity>().Search(search);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Remove(TEntity entity)
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

        public TEntity SingleNochange(int id)
        {
            var old = SingleOrDefault(id);
            Context.Entry(old).State = EntityState.Unchanged;
            return old;
        }

        public TEntity SingleOrDefaultNochange(int id)
        {
            var old = SingleOrDefault(id);
            Context.Entry(old).State = EntityState.Unchanged;
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
