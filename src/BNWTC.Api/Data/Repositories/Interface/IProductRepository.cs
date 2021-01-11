using BNWTC.Api.Models.Entities;

using System.Threading.Tasks;

namespace BNWTC.Api.Data.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> FindBySku(int sku);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Remove(Product product);
    }
}
