using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Implementation.Factories;
using Boticario.Backend.Modules.Products.Models;
using NUnit.Framework;
using System;

namespace Boticario.Backend.Modules.Products.Tests
{
    public class DefaultProductFactoryTests
    {
        private DefaultProductFactory productFactory;

        [SetUp]
        public void Setup()
        {
            this.productFactory = new DefaultProductFactory();
        }

        [Test]
        public void When_SkuIsLessThan1_Should_ThrowException()
        {
            Exception exception = Assert.Throws<ProductValidationException>(() =>
            {
                this.productFactory.Create(0, "Abc");
            });

            Assert.AreEqual("SKU is invalid!", exception.Message);
        }

        [Test]
        public void When_NameIsEmptyOrNull_Should_ThrowException()
        {
            Exception exception = Assert.Throws<ProductValidationException>(() =>
            {
                this.productFactory.Create(1, string.Empty);
            });

            Assert.AreEqual("Name is missing!", exception.Message);
        }

        [Test]
        public void When_ParametersAreValid_Should_ReturnObject()
        {
            IProductEntity product = this.productFactory.Create(1, "Abc");
         
            Assert.AreEqual(1, product.Sku);
            Assert.AreEqual("Abc", product.Name);
        }

        [Test]
        public void When_NameHasExtraSpaces_Should_ReturnNameTrimed()
        {
            IProductEntity product = this.productFactory.Create(1, " Abc ");

            Assert.AreEqual("Abc", product.Name);
        }
    }
}