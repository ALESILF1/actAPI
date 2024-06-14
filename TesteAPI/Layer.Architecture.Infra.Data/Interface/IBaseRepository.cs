using Layer.Architecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Layer.Architecture.Infra.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Insert(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task Delete(int id);

        Task<IList<TEntity>> Select();

        Task<TEntity> Select(int id);
    }
}
