using Xunit;
using MediatR;
using AutoMapper;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BelezaNaWeb.Domain.Queries;
using BelezaNaWeb.Api.Controllers;
using BelezaNaWeb.Domain.Constants;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Test.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BelezaNaWeb.Domain.Entities.Impl;
using System;
using BelezaNaWeb.Domain.Dtos;

namespace BelezaNaWeb.Test.Controllers
{
    public sealed class ProductControllerTests : IClassFixture<ContainerFixture>
    {
        #region Public Properties

        private readonly ProductController _controller;

        #endregion

        #region Constructors

        public ProductControllerTests(ContainerFixture fixture)
        {
            var mapper = fixture.ServiceProvider.GetService<IMapper>();
            var mediat = fixture.ServiceProvider.GetService<IMediator>();
            var logger = fixture.ServiceProvider.GetService<ILogger<ProductController>>();

            _controller = new ProductController(logger, mapper, mediat);            
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task Products_List_ReturnsOkResponse()
        {
            var result = await _controller.List();             
            var actual = Assert.IsType<OkObjectResult>(result);
            var expect = (int)HttpStatusCode.OK;

            Assert.Equal(expect, actual.StatusCode);
            Assert.IsAssignableFrom<ListProductResult>(actual.Value);
        }

        [Fact]
        public async Task Products_Get_ReturnsOkResponse()
        {
            var result = await _controller.Get(sku: 43264);
            var actual = Assert.IsType<OkObjectResult>(result);
            var expect = (int)HttpStatusCode.OK;

            Assert.Equal(expect, actual.StatusCode);
            Assert.IsAssignableFrom<GetProductResult>(actual.Value);
        }

        [Fact]
        public async Task Products_Get_ReturnsCorrectData()
        {
            var result = await _controller.Get(sku: 43264);
            var actual = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<GetProductResult>(actual.Value);

            var expectStatusCode = (int)HttpStatusCode.OK;
            var expectSku = 43264;
            var expectIsMarketable = true;
            var expectInventoryQuantity = 15;
            var expectName = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
            var expectWarehousesCount = 2;

            Assert.Equal(expectStatusCode, actual.StatusCode);
            Assert.Equal(expectSku, output.Sku);
            Assert.Equal(expectName, output.Name);
            Assert.Equal(expectIsMarketable, output.Inventory.IsMarketable);
            Assert.Equal(expectInventoryQuantity, output.Inventory.Quantity);
            Assert.Equal(expectWarehousesCount, output.Inventory.Warehouses.Count());
        }

        [Fact]
        public async Task Products_Get_ReturnsCorrectWarehousesData()
        {
            var result = await _controller.Get(sku: 43264);
            var actual = Assert.IsType<OkObjectResult>(result);
            var output = Assert.IsType<GetProductResult>(actual.Value);

            var expectedECommerce = new WarehouseDto(quantity: 12, locality: "SP", type: "ECOMMERCE");
            var expectedPhysicalStore = new WarehouseDto(quantity: 3, locality: "MOEMA", type: "PHYSICAL_STORE");

            Assert.Contains(expectedECommerce, output.Inventory.Warehouses);
            Assert.Contains(expectedPhysicalStore, output.Inventory.Warehouses);            
        }

        [Fact]
        public async Task Products_Get_NotFoundSku_ThrowsApiException()
        {
            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Get(sku: int.MaxValue));
            
            var expectCode = ErrorConstants.ProductNotFound.Code;
            var expectName = ErrorConstants.ProductNotFound.Name;
            var expectMessage = ErrorConstants.ProductNotFound.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }

        [Fact]
        public async Task Products_Get_SkuLessThanZero_ThrowsApiException()
        {
            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Get(sku: int.MinValue));

            var expectCode = ErrorConstants.ProductInvalidSku.Code;
            var expectName = ErrorConstants.ProductInvalidSku.Name;
            var expectMessage = ErrorConstants.ProductInvalidSku.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }

        [Fact]
        public async Task Products_Get_SkuEqualZero_ThrowsApiException()
        {
            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Get(sku: int.MinValue));

            var expectCode = ErrorConstants.ProductInvalidSku.Code;
            var expectName = ErrorConstants.ProductInvalidSku.Name;
            var expectMessage = ErrorConstants.ProductInvalidSku.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }


        #endregion

    }
}
