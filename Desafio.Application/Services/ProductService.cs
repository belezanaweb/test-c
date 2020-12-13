using Desafio.Application.Interfaces;
using Desafio.Application.Mapping;
using Desafio.Application.ViewModels.CreateUpdate;
using Desafio.Application.ViewModels.Read;
using Desafio.Domain.ComandHandler;
using Desafio.Domain.Command;
using Desafio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ProductService :  IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductComandsHandler _productComandsHandler;

        public ProductService(
            IProductRepository productRepository, 
            IWarehouseRepository warehouseRepository,
            IProductComandsHandler productComandsHandler
        )
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _productComandsHandler = productComandsHandler;
        }

        public CommandResult Create(ProductCreateUpdateReadViewModel viewModel)
        {
            var productCreate = ProductCreateUpdateMapping.GetProductCreateCommand(viewModel);
            var warehouseCommandList = ProductCreateUpdateMapping.GetWarehouseList(viewModel);
            return _productComandsHandler.Create(productCreate, warehouseCommandList);
        }

        public ProductReadViewModel Read(int sku)
        {
            var product = _productRepository.Read(sku);
            var warehouseList = _warehouseRepository.Read(sku);
            return ProductReadMapping.GetProduct(product, warehouseList);
        }

        public CommandResult Update(ProductCreateUpdateReadViewModel viewModel)
        {
            var productUpdate = ProductCreateUpdateMapping.GetProductUpdateCommand(viewModel);
            var warehouseCommandList = ProductCreateUpdateMapping.GetWarehouseList(viewModel);
            return _productComandsHandler.Update(productUpdate, warehouseCommandList);

        }

        public CommandResult Delete(int sku)
        {
            var productDelete = ProductCreateUpdateMapping.GetProductDeleteCommand(sku);
            return _productComandsHandler.Delete(productDelete);
        }

    }
}
