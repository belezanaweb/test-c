using System.Collections.Generic;
using System.Threading.Tasks;
using BelezaNaWeb.Api.Model.Entities;

namespace BelezaNaWeb.Api.Data.Repositories.Contract
{
    public interface IProductRepository
    {
        Task<List<Product>> Index();
        Task<Product> Store(Product product);
        Task<Product> Show(int sku);
        Task<Product> Update(Product product);
        Task<bool> Destroy(Product product);
    }
}
