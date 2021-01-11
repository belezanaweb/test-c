using BNWTC.Api.Models.Entities;

using System.Threading.Tasks;

namespace BNWTC.Api.Services.IServices
{
    public interface IProductSerices
    {
        Task<Product> FindBySku(int sku);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Remove(Product product);
    }
}
