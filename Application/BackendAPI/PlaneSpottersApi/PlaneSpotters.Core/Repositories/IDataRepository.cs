using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Repositories
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity dbEntity, TEntity entity);
        bool Delete(long id);
    }
}
