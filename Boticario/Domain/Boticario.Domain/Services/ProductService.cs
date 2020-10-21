using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces.Repositories;
using Boticario.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Boticario.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductBySku(int sku)
        {
            // Mock one product
            MockOneProduct();

            return _productRepository.GetProductBySku(sku);
        }

        public Product Add(Product model)
        {
            var product = GetProductBySku(model.Sku);

            if (product != null)
                throw new ApplicationException("Duplicate sku");

            return _productRepository.Add(model);
        }

        public Product Update(Product model) => _productRepository.Update(model);

        public bool Delete(int sku) => _productRepository.Delete(sku);

        private void MockOneProduct()
        {
            var product = new Product(43264, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g")
            {
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("POMPEIA", 12, "ECOMMERCE"),
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            }
                }
            };

            _productRepository.Add(product);
        }
    }
}
