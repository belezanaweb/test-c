using Beleza.Na.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.Repository.Interfaces
{
    public interface IProductRepository
    {
        ProductDomain GetProduct(int sku);
        List<ProductDomain> GetProducts();
        bool DeleteProduct(int sku);

        bool CreateProduct(ProductDomain product);
        bool UpdateProduct(ProductDomain product);
    }
}
