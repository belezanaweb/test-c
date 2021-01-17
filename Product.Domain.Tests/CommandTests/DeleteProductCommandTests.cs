using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Entities;
using Product.Domain.Handlers;
using Product.Domain.Tests.Repositories;

namespace Product.Domain.Tests.CommandTests
{
    [TestClass]
    public class DeleteProductCommandTests
    {
        [TestMethod]
        public void valid_command()
        {
            DeleteProductCommand validCommand = new DeleteProductCommand(1234);
            validCommand.Validate();

            Assert.AreEqual(validCommand.Valid, true);
        }

        [TestMethod]
        public void invalid_command()
        {
            DeleteProductCommand invalidCommand = new DeleteProductCommand(0);
            invalidCommand.Validate();

            Assert.AreEqual(invalidCommand.Valid, false);
        }

    }
}
