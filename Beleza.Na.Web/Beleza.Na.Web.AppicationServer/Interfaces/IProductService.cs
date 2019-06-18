using Beleza.Na.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.AppicationServer.Interfaces
{
    public interface IProductService
    {
        ProductDomain GetProduct(int sku);
        bool DeleteProduct(int sku);

        bool CreateProduct(ProductDomain product);
        bool UpdateProduct(ProductDomain product);
    }
}
