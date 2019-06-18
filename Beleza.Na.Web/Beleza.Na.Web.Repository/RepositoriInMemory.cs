using Beleza.Na.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.Repository
{
    public static class RepositoriInMemory
    {

        private static List<ProductDomain> Products;

        public static List<ProductDomain> GetProducts()
        {
            if (Products == null)
            {
                Products = new List<ProductDomain>();
            }
            return Products;
        }

        public static void CreateProduct(ProductDomain product)
        {
            product.Sku = new Random().Next(1, 9999999);// identity do banco de dados
            Products.Add(product);
        }

        public static void DeleteProduct(int sku)
        {
            var product = Products.SingleOrDefault(p => p.Sku == sku);

            if (product != null)
            {
                Products.Remove(product);
            }
        }

        public static void UpdateProduct(ProductDomain prod)
        {
            var product = Products.SingleOrDefault(p => p.Sku == prod.Sku);

            if (product != null)
            {
                DeleteProduct(prod.Sku);
                CreateProduct(prod);
            }
        }

        public static List<UserDomain> GetUserDomains()
        {
            return new List<UserDomain>
            {
                new UserDomain { Name = "leonardo", Password = "1234" },
                new UserDomain { Name = "thiago", Password = "5678" }
            };
        }

    }
}
