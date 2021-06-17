using AutoMapper;
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
        private readonly IMapper _mapper; 

        public ProductApp(IUnitOfWork uow, IProductRepository productRepository, IWarehouseRepository warehouseRepository, IMapper mapper) : base(uow)
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public bool Add(NewProductTO newProduct)
        {
            var product = _productRepository.GetBySku(newProduct.Sku);

            if (product != null)
                return false;

            product = new Product(newProduct.Sku, newProduct.Name);
            _productRepository.Add(product);

            _warehouseRepository.Add(newProduct.Inventory.Warehouses.Select(warehouse => new Warehouse(newProduct.Sku, warehouse.Locality, warehouse.Quantity, warehouse.Type)).ToList());

            return Save();
        }

        public bool Delete(int sku)
        {
            var product = _productRepository.GetBySku(sku);
            var warehouses = _warehouseRepository.GetAllBySku(sku);

            _productRepository.Remove(product);

            foreach (var warehouse in warehouses)
            {
                _warehouseRepository.Remove(warehouse);
            }

            return Save();
        }

        public ProductTO Get(int sku)
        {
            var product = _productRepository.GetBySku(sku);
            if (product == null)
                return null;

            product.Warehouses = _warehouseRepository.GetAllBySku(sku);

            return _mapper.Map<ProductTO>(product);
        }

        public bool Update(NewProductTO newProduct)
        {
            var product = _productRepository.GetBySku(newProduct.Sku);
            if (product == null)
                return false;

            var warehouses = _warehouseRepository.GetAllBySku(product.Sku);

            foreach (var warehouse in warehouses)
            {
                _warehouseRepository.Remove(warehouse);
            }

            product.Update(newProduct.Sku, newProduct.Name);

            _warehouseRepository.Add(newProduct.Inventory.Warehouses.Select(warehouse => new Warehouse(newProduct.Sku, warehouse.Locality, warehouse.Quantity, warehouse.Type)).ToList());

            return Save();
        }
    }
}
