using Beleza.Na.Web.Domain;
using Beleza.Na.Web.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool CreateProduct(ProductDomain product)
        {
            RepositoriInMemory.CreateProduct(product);

            return true;
        }

        public bool DeleteProduct(int sku)
        {
            RepositoriInMemory.DeleteProduct(sku);

            return true;
        }

        public ProductDomain GetProduct(int sku)
        {
            return RepositoriInMemory.GetProducts().SingleOrDefault(p => p.Sku == sku);
        }

        public List<ProductDomain> GetProducts()
        {
            return RepositoriInMemory.GetProducts();
        }

        public bool UpdateProduct(ProductDomain product)
        {
            RepositoriInMemory.UpdateProduct(product);

            return true;
        }
    }
}
