using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Entities;
using Product.Domain.Handlers;
using Product.Domain.Tests.GenerateData;
using Product.Domain.Tests.Repositories;

namespace Product.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateProductHandlerTests
    {
        private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public UpdateProductHandlerTests()
        {

        }        

        [TestMethod]
        public void valid_command_update_product()
        {
            Entities.Product product = GenerateProductData.CreateProductValid();

            UpdateProductCommand validCommand = new UpdateProductCommand(product.Sku, product.Name, product.Inventory);
            _result = (GenericCommandResult)_handler.Handle(validCommand);

            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public void invalid_command_without_inventory_stop_execution()
        {

            UpdateProductCommand invalidCommand = new UpdateProductCommand();
            invalidCommand.Sku = 1234;
            invalidCommand.Name = "Produto Teste";
            invalidCommand.Inventory = null;
            _result = (GenericCommandResult)_handler.Handle(invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void invalid_command_without_warehouses_stop_execution()
        {
            Entities.Product product = GenerateProductData.CreateProductWarehouseNullInvalid();

            UpdateProductCommand invalidCommand = new UpdateProductCommand(product.Sku, product.Name, product.Inventory);
            _result = (GenericCommandResult)_handler.Handle(invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }
    }
}
