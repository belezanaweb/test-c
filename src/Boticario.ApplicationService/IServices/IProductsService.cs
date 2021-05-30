using Boticario.Domain.Models;
using Boticario.Domain.Search;
using Boticario.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.ApplicationService.IServices
{
    public interface IProductsService
    {
        Task<Products> Save(ProductViewModel product);
        Task<Products> Update(int sku, ProductUpdateViewModel product);
        Task<Products> Get(int sku);
        Task<IEnumerable<Products>> Get();
        Task<IList<Products>> Search(ProductSearch filterQuery);
        Task<Products> Delete(int sku);
    }

}
