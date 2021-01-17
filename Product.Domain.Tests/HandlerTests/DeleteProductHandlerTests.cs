using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Handlers;
using Product.Domain.Tests.Repositories;

namespace Product.Domain.Tests.HandlerTests
{
    [TestClass]
    public class DeleteProductHandlerTests
    {
        public DeleteProductHandlerTests()
        {

        }

        private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void valid_command_delete_product()
        {
            DeleteProductCommand validCommand = new DeleteProductCommand(1234);
            _result = (GenericCommandResult)_handler.Handle(validCommand);

            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public void invalid_command_nonexistent_sku_stop_execution()
        {
            DeleteProductCommand invalidCommand = new DeleteProductCommand(-1);
            _result = (GenericCommandResult)_handler.Handle(invalidCommand);

            Assert.AreEqual(_result.Success, false);
        }

    }
}
