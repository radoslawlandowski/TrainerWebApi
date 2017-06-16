using System.Collections.Generic;

namespace TrainerWebApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity item);
        TEntity Remove(TEntity item);
        void Update(TEntity item);
    }
}