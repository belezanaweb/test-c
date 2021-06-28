using GrupoBoticario.Domain.Models.Product;
using GrupoBoticario.Domain.Payload.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.Application.Interfaces
{
    public interface IProductApplicationService
    {
        Task AddProduct(IEnumerable<ProductSavePayload> payload);
        Task UpdateProduct(IEnumerable<ProductUpdatePayload> payload);
        Task DeleteProduct(long sku);
        Task<ProductViewModel> ObterPorId(long sku);

        Task<IEnumerable<ProductViewModel>> ObterTodos();
    }
}
