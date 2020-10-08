using System.Linq;

namespace Caspian.Common.Service
{
    public interface ISimpleService<TEntity>
    {
        IQueryable<TEntity> GetAll(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();

        void Add(TEntity entity);

        void Remove(TEntity entity);

        TEntity Single(int id);

        TEntity SingleOrDefault(int id);
    }
}
