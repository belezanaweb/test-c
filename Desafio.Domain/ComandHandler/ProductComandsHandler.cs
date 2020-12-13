using Desafio.Domain.Command;
using Desafio.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Desafio.Domain.Interfaces;

namespace Desafio.Domain.ComandHandler
{
    public class ProductComandsHandler : IProductComandsHandler
    {
        private IProductRepository _productRepository;
        private IWarehouseRepository _warehouseRepository;

        public ProductComandsHandler(
            IProductRepository productRepository,
            IWarehouseRepository warehouseRepository
        )
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
        }

        public CommandResult Create(ProductCreateCommand productCreate, List<WarehouseCreateCommand> warehouseCommandList)
        {
            if (productCreate.IsValid() == false)
            {
                return CommandResult.Error(productCreate.ValidationResult.ToString());
            }

            if (_productRepository.Exists(productCreate.Sku) == true)
            {
                return CommandResult.Error("Sku do produto já existe.");
            }

            foreach (var item in warehouseCommandList)
            {
                if (item.IsValid() == false)
                {
                    return CommandResult.Error(item.ValidationResult.ToString());
                }
            }

            var product = new Product(sku: productCreate.Sku, name: productCreate.Name);
            var warehouseList = warehouseCommandList
                .Select(x => new Warehouse(
                    sku: product.Sku,
                    locality: x.Locality,
                    quantity: x.Quantity,
                    type: x.Type
                ));

            _productRepository.Create(product);
            foreach (var warehouse in warehouseList)
            {
                _warehouseRepository.Create(warehouse);
            }

            return CommandResult.Ok();
        }

        public CommandResult Update(ProductUpdateCommand productUpdate, List<WarehouseCreateCommand> warehouseCommandList)
        {
            if (productUpdate.IsValid() == false)
            {
                return CommandResult.Error(productUpdate.ValidationResult.ToString());
            }

            if (_productRepository.Exists(productUpdate.Sku) == false)
            {
                return CommandResult.Error("Sku do produto não existe.");
            }


            foreach (var item in warehouseCommandList)
            {
                if (item.IsValid() == false)
                {
                    return CommandResult.Error(item.ValidationResult.ToString());
                }
            }

            
            var product = new Product(sku: productUpdate.Sku, name: productUpdate.Name);
            var warehouseList = warehouseCommandList
                .Select(x => new Warehouse(
                    sku: product.Sku,
                    locality: x.Locality,
                    quantity: x.Quantity,
                    type: x.Type
                ));

            _productRepository.Update(product);
            _warehouseRepository.Delete(product.Sku);
            foreach (var warehouse in warehouseList)
            {
                _warehouseRepository.Create(warehouse);
            }

            return CommandResult.Ok();

        }

        public CommandResult Delete(ProductDeleteCommand productDelete)
        {
            if (productDelete.IsValid() == false)
            {
                return CommandResult.Error(productDelete.ValidationResult.ToString());
            }

            if (_productRepository.Exists(productDelete.Sku) == false)
            {
                return CommandResult.Error("Sku do produto não existe.");
            }

            _productRepository.Delete(productDelete.Sku);
            _warehouseRepository.Delete(productDelete.Sku);

            return CommandResult.Ok();
        }

    }
}
