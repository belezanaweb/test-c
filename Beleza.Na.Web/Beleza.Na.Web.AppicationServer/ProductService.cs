using Beleza.Na.Web.AppicationServer.Interfaces;
using Beleza.Na.Web.Domain;
using Beleza.Na.Web.Repository;
using Beleza.Na.Web.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.AppicationServer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CreateProduct(ProductDomain product)
        {
            var products = _productRepository.GetProducts();

            if (products.FirstOrDefault(p => p.Sku == product.Sku) != null)
            {
                throw new Exception($"Já existe produto com o Sku { product.Sku} .");
            }

            return _productRepository.CreateProduct(product);

        }

        public bool DeleteProduct(int sku)
        {
            return _productRepository.DeleteProduct(sku);
        }

        public ProductDomain GetProduct(int sku)
        {
            ProductDomain product = _productRepository.GetProduct(sku);

            if (product != null)
            {
                product.Inventory.Quantity = product.Inventory.Warehouses.Count();
                product.IsMarketable = product.Inventory.Quantity > 0;
            }

            return product;
        }

        public bool UpdateProduct(ProductDomain product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
