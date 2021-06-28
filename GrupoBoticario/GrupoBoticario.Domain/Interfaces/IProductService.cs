using GrupoBoticario.Domain.Models.Product;
using GrupoBoticario.Domain.Payload.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.Domain.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(IEnumerable<ProductSavePayload> payloads);
        Task UpdateProduct(IEnumerable<ProductUpdatePayload> payloads);
        Task DeleteProduct(long sku);
        Task<ProductViewModel> ObterPorId(long sku);

        Task<IEnumerable<ProductViewModel>> ObterTodos();
    }
}
