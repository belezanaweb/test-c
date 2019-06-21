using BW.Domain;
using System.Threading.Tasks;

namespace BW.Application.Repository.Product
{
    public interface IProductRepositoryrWriteOnlyRepository
    {
        Task Add(ProductDomain product);
        Task Update(ProductDomain product);
        Task Delete(int sku);
    }
}
