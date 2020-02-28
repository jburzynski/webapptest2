using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IRepository<TEntity>
    {
        void Add(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
    }
}