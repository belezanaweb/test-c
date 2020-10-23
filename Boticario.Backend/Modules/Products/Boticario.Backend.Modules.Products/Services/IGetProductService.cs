using Boticario.Backend.Modules.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Services
{
    public interface IGetProductService
    {
        Task<IList<IProduct>> Get(int sku);
    }
}
