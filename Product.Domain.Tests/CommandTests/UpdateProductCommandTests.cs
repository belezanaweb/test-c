using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Entities;
using Product.Domain.Handlers;
using Product.Domain.Tests.GenerateData;
using Product.Domain.Tests.Repositories;

namespace Product.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateProductCommandTests
    {
        public UpdateProductCommandTests()
        {

        }

        [TestMethod]
        public void valid_command()
        {
            Entities.Product product = GenerateProductData.CreateProductValid();

            UpdateProductCommand validCommand = new UpdateProductCommand(product.Sku, product.Name, product.Inventory);
            validCommand.Validate();

            Assert.AreEqual(validCommand.Valid, true);
        }

        [TestMethod]
        public void invalid_command_without_inventory()
        {

            UpdateProductCommand invalidCommand = new UpdateProductCommand();
            invalidCommand.Sku = 1234;
            invalidCommand.Name = "Produto Teste";
            invalidCommand.Inventory = null;
            invalidCommand.Validate();

            Assert.AreEqual(invalidCommand.Valid, false);
        }

        [TestMethod]
        public void invalid_command_without_warehouses()
        {
            Entities.Product product = GenerateProductData.CreateProductWarehouseNullInvalid();
            UpdateProductCommand invalidCommand = new UpdateProductCommand(product.Sku, product.Name, product.Inventory);
            invalidCommand.Validate();

            Assert.AreEqual(invalidCommand.Valid, false);
        }
    }
}
