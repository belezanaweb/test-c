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
    public class CreateProductHandlerTests
    {
        private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateProductHandlerTests()
        {

        }
              

        [TestMethod]
        public void valid_command_create_product()
        {
            Entities.Product product = GenerateProductData.CreateProductValid();          

            CreateProductCommand validCommand = new CreateProductCommand(product.Sku, product.Name, product.Inventory);
            _result = (GenericCommandResult)_handler.Handle(validCommand);

            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public void invalid_command_without_inventory_stop_execution()
        {

            CreateProductCommand invalidCommand = new CreateProductCommand();
            invalidCommand.Sku = 12345;
            invalidCommand.Name = "Produto Teste";
            invalidCommand.Inventory = null;
            _result = (GenericCommandResult)_handler.Handle(invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void invalid_command_without_warehouses_stop_execution()
        {
            Entities.Product product = GenerateProductData.CreateProductWarehouseNullInvalid();

            CreateProductCommand invalidCommand = new CreateProductCommand(product.Sku, product.Name, product.Inventory);
            _result = (GenericCommandResult)_handler.Handle(invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }
    }
}
