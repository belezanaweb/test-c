using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.Interfaces.Application;
using BoticarioAPI.Domain.Interfaces.Repository;
using BoticarioAPI.Domain.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Application.Application
{
    public class ProductApp : AppBase, IProductApp
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public ProductApp(IUnitOfWork uow, IProductRepository productRepository, IWarehouseRepository warehouseRepository) : base(uow)
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
        }

        public bool Add(NewProductTO newProduct)
        {
            var product = new Product(newProduct.Sku, newProduct.Name);
            _productRepository.Add(product);
            return Save();
        }

        public bool Delete(int sku)
        {
            throw new NotImplementedException();
        }

        public Product Get(int sku)
        {
            return _productRepository.GetBySku(sku);
        }

        public bool Update(NewProductTO product)
        {
            throw new NotImplementedException();
        }
    }
}
