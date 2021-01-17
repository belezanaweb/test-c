using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Entities;
using Product.Domain.Handlers;
using Product.Domain.Tests.Repositories;
using Product.Domain.Tests.GenerateData;

namespace Product.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateProductCommandTests
    {
        public CreateProductCommandTests()
        {

        }

        

        [TestMethod]
        public void valid_command()
        {
            Entities.Product product = GenerateProductData.CreateProductValid();

            CreateProductCommand validCommand = new CreateProductCommand(product.Sku, product.Name, product.Inventory);
            validCommand.Validate();

            Assert.AreEqual(validCommand.Valid, true);
        }

        [TestMethod]
        public void invalid_command_without_inventory()
        {

            CreateProductCommand invalidCommand = new CreateProductCommand();
            invalidCommand.Sku = 12345;
            invalidCommand.Name = "Produto Teste";
            invalidCommand.Inventory = null;
            invalidCommand.Validate();

            Assert.AreEqual(invalidCommand.Valid, false);
        }

        [TestMethod]
        public void invalid_command_without_warehouses()
        {
            Entities.Product product = GenerateProductData.CreateProductWarehouseNullInvalid();
            CreateProductCommand invalidCommand = new CreateProductCommand(product.Sku, product.Name, product.Inventory);
            invalidCommand.Validate();

            Assert.AreEqual(invalidCommand.Valid, false);
        }
    }
}
