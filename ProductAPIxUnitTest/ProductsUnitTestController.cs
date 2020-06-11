using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Context;
using ProductAPI.Controllers;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductAPIxUnitTest
{
    public class ProductsUnitTestController
    {

        // teste do metodo get

        [Fact]
        public void GetProducts_Return_OkResult()
        {
            //Arrange
            var controller = new ProductsController();

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<List<Product>>(data.Value);
        }

        [Fact]
        public void GetProducts_Return_BadRequestResult()
        {
            //Arrange
            var controller = new ProductsController();

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public void GetProducts_MatchResult()
        {
            var controller = new ProductsController();

            var data = controller.Get();

            Assert.IsType<List<Product>>(data.Value);
            var prod = data.Value.Should().BeAssignableTo<List<Product>>().Subject;

            Assert.Equal("L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g", prod[0].Name);
            Assert.Equal(43264, prod[0].Sku);


        }
    }
}
