using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.IRepositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.Domain.IRepositories
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
        Task<ProductEntity> ObterPorId(long sku);
        Task<IEnumerable<ProductEntity>> ObterTodos();
    }
}
