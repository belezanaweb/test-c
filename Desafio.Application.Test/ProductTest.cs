using Desafio.Application.Services;
using Desafio.Application.ViewModels.CreateUpdate;
using Desafio.Application.ViewModels.Read;
using Desafio.Domain.ComandHandler;
using Desafio.Domain.Command;
using Desafio.Infra.Data.Context;
using Desafio.Infra.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Desafio.Application.Test
{
    [TestClass]
    public class ProductTest
    {
        private MainContext _mainContext;
        private ProductRepository _productRepository;
        private WarehouseRepository _warehouseRepository;
        private ProductComandsHandler _productComandsHandler;
        private ProductService _productService;

        [TestInitialize]
        public void Initialize()
        {
            _mainContext = new MainContext();
            _productRepository = new ProductRepository(_mainContext);
            _warehouseRepository = new WarehouseRepository(_mainContext);
            _productComandsHandler = new ProductComandsHandler(_productRepository, _warehouseRepository);
            _productService = new ProductService(_productRepository, _warehouseRepository, _productComandsHandler);
        }

        [TestMethod]
        [DataRow("43264-create.json", "43264-read-after-create.json", "43264-update.json", "43264-read-after-update.json")]
        public void CrudTeste(string createJson, string afterCreateJson, string updateJson, string afterUpdateJson)
        {
            var sku = createProduct(createJson, "Criação do objeto não retornou Ok.");
            duplicateProduct(createJson, "O produto foi duplicado");
            compareProduct(afterCreateJson, sku, "O resultado da busca após a criação difere do esperado.");
            updateProduct(updateJson, "Atualização do objeto não retornou Ok.");
            compareProduct(afterUpdateJson, sku, "O resultado da busca após a atualização difere do esperado.");
            deleteProduct(sku, "Deleção do objeto não retornou Ok.");
            productNotFound(sku, "O produto foi encontrado mesmo após a exclusão");
        }

        private int createProduct(string json, string msg)
        {
            var viewModel = JsonHelper.Deserialize<ProductCreateUpdateReadViewModel>(json);
            var result = _productService.Create(viewModel);
            Assert.AreEqual(CommandResultStatus.Ok, result.Status, msg);
            return viewModel.Sku;
        }        
        
        private void duplicateProduct(string json, string msg)
        {
            var viewModel = JsonHelper.Deserialize<ProductCreateUpdateReadViewModel>(json);
            var result = _productService.Create(viewModel);
            Assert.AreEqual(CommandResultStatus.Error, result.Status, msg);
        }

        private void updateProduct(string json, string msg)
        {
            var viewModel = JsonHelper.Deserialize<ProductCreateUpdateReadViewModel>(json);
            var result = _productService.Update(viewModel);
            Assert.AreEqual(CommandResultStatus.Ok, result.Status, msg);
        }

        private void deleteProduct(int sku, string msg)
        {
            var result = _productService.Delete(sku);
            Assert.AreEqual(CommandResultStatus.Ok, result.Status, msg);
        }

        private void compareProduct(string json, int sku, string msg)
        {
            var readViewModel = JsonHelper.Serialize<ProductReadViewModel>(
                _productService.Read(sku)
            );
            var compareViewModel = JsonHelper.Serialize<ProductReadViewModel>(
                JsonHelper.Deserialize<ProductReadViewModel>(json)
            );
            Assert.AreEqual(compareViewModel, readViewModel, msg);
        }

        private void productNotFound(int sku, string msg)
        {
            var readViewModel = _productService.Read(sku);
            Assert.IsNull(readViewModel, msg);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mainContext = null;
            _productRepository = null;
            _warehouseRepository = null;
            _productComandsHandler = null;
            _productService = null;
        }
    }
}
