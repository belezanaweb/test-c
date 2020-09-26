using Xunit;
using System;
using MediatR;
using System.Net;
using AutoMapper;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using BelezaNaWeb.Api.Requests;
using BelezaNaWeb.Domain.Queries;
using BelezaNaWeb.Api.Controllers;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Constants;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Test.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.Test.Controllers
{
    public sealed class ProductControllerTests : IClassFixture<ContainerFixture>
    {
        #region Private Read-Only Fields

        private readonly Random random = new Random(1);

        #endregion

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

        [Fact]
        public async Task Products_Delete_ReturnsNoContentResponse()
        {            
            var model = new CreateProductRequest
            (
                  sku: 123456
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 1, locality: "SP", type: "MAIN_STORAGE")
                    }
                )
            );

            await _controller.Create(new ApiVersion(1, 0), model);
            
            var result = await _controller.Delete(sku: model.Sku);
            var actual = Assert.IsType<NoContentResult>(result);
            var expect = (int)HttpStatusCode.NoContent;

            Assert.Equal(expect, actual.StatusCode);
        }

        [Fact]
        public async Task Products_Delete_NotFoundSku_ThrowsApiException()
        {
            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Delete(sku: int.MaxValue));

            var expectCode = ErrorConstants.ProductNotFound.Code;
            var expectName = ErrorConstants.ProductNotFound.Name;
            var expectMessage = ErrorConstants.ProductNotFound.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }

        [Fact]
        public async Task Products_Create_ReturnsCreatedResponse()
        {
            var model = new CreateProductRequest
            (
                  sku: random.Next(1, int.MaxValue)
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 10, locality: "SP", type: "MAIN_STORAGE"),
                        new CreateProductWarehouseRequest(quantity: 2,  locality: "RJ", type: "ECOMMERCE")
                    }
                )
            );

            var result = await _controller.Create(new ApiVersion(1, 0), model);
            var actual = Assert.IsType<CreatedAtActionResult>(result);
            var output = Assert.IsType<CreateProductResult>(actual.Value);

            var expectStatusCode = (int)HttpStatusCode.Created;
            var expectSku = model.Sku;
            var expectIsMarketable = true;
            var expectInventoryQuantity = 12;
            var expectName = "TEST";
            var expectWarehousesCount = 2;

            Assert.Equal(expectStatusCode, actual.StatusCode);
            Assert.Equal(expectSku, output.Sku);
            Assert.Equal(expectName, output.Name);
            Assert.Equal(expectIsMarketable, output.Inventory.IsMarketable);
            Assert.Equal(expectInventoryQuantity, output.Inventory.Quantity);
            Assert.Equal(expectWarehousesCount, output.Inventory.Warehouses.Count());
        }

        [Fact]
        public async Task Products_Create_InvalidBody_ThrowsApiException()
        {
            var model = new CreateProductRequest(sku: 123456, name: "TEST", inventory: null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Create(apiVersion: new ApiVersion(1, 0), model));
        }

        [Fact]
        public async Task Products_Create_DuplicatedSku_ThrowsApiException()
        {
            var model = new CreateProductRequest
            (
                  sku: 43264
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 1, locality: "SP", type: "MAIN_STORAGE")
                    }
                )
            );

            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Create(apiVersion: new ApiVersion(1,0), model));

            var expectCode = ErrorConstants.ProductAlreadyExists.Code;
            var expectName = ErrorConstants.ProductAlreadyExists.Name;
            var expectMessage = ErrorConstants.ProductAlreadyExists.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }

        [Fact]
        public async Task Products_Create_DuplicatedWarehouses_ThrowsApiException()
        {
            var model = new CreateProductRequest
            (
                  sku: random.Next(1, int.MaxValue)
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 10, locality: "SP", type: "MAIN_STORAGE"),
                        new CreateProductWarehouseRequest(quantity: 2,  locality: "RJ", type: "ECOMMERCE"),
                        new CreateProductWarehouseRequest(quantity: 3,  locality: "SP", type: "MAIN_STORAGE")
                    }
                )
            );

            var actual = await Assert.ThrowsAsync<ValidationException>(() => _controller.Create(apiVersion: new ApiVersion(1, 0), model));            
            
            Assert.Contains(actual.Errors, x => x.ErrorMessage.Equals("The warehouse must be unique."));
            Assert.Contains(actual.Errors, x => x.PropertyName.Equals(nameof(CreateProductInventoryRequest.Warehouses)));
        }

        [Fact]
        public async Task Products_Edit_ReturnsCreatedResponse()
        {
            var createModel = new CreateProductRequest
            (
                  sku: random.Next(10, int.MaxValue)
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 10, locality: "SP", type: "MAIN_STORAGE"),
                        new CreateProductWarehouseRequest(quantity: 2,  locality: "RJ", type: "ECOMMERCE")
                    }
                )
            );
            await _controller.Create(new ApiVersion(1, 0), createModel);

            var editModel = new EditProductRequest(
                name: "UPDATED",
                inventory: new EditProductInventoryRequest
                (
                    warehouses: new EditProductWarehouseRequest[]
                    {
                        new EditProductWarehouseRequest(quantity: 15, locality: "SP", type: "MAIN_STORAGE"),
                        new EditProductWarehouseRequest(quantity: 3,  locality: "RJ", type: "ECOMMERCE"),
                        new EditProductWarehouseRequest(quantity: 2,  locality: "MG", type: "CONTAINER")
                    }
                )

            );

            var result = await _controller.Edit(sku: createModel.Sku, model: editModel);            
            var actual = Assert.IsType<NoContentResult>(result);
            var expect = (int)HttpStatusCode.NoContent;

            Assert.Equal(expect, actual.StatusCode);
        }

        [Fact]
        public async Task Products_Edit_NotFoundSku_ThrowsApiException()
        {
            var model = new EditProductRequest
            (
                  name: "TEST"
                , inventory: new EditProductInventoryRequest
                (
                    warehouses: new EditProductWarehouseRequest[]
                    {
                        new EditProductWarehouseRequest(quantity: 1, locality: "SP", type: "MAIN_STORAGE")
                    }
                )
            );
            var actual = await Assert.ThrowsAsync<ApiException>(() => _controller.Edit(sku: int.MaxValue, model));

            var expectCode = ErrorConstants.ProductNotFound.Code;
            var expectName = ErrorConstants.ProductNotFound.Name;
            var expectMessage = ErrorConstants.ProductNotFound.Message;

            Assert.Equal(expectCode, actual.Code);
            Assert.Equal(expectName, actual.Name);
            Assert.Equal(expectMessage, actual.Message);
        }

        [Fact]
        public async Task Products_Edit_InvalidBody_ThrowsApiException()
        {
            var model = new EditProductRequest(name: "TEST", inventory: null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Edit(sku: int.MaxValue, model));
        }

        [Fact]
        public async Task Products_Edit_DuplicatedWarehouses_ThrowsApiException()
        {
            var createModel = new CreateProductRequest
            (
                  sku: random.Next(3, int.MaxValue)
                , name: "TEST"
                , inventory: new CreateProductInventoryRequest
                (
                    warehouses: new CreateProductWarehouseRequest[]
                    {
                        new CreateProductWarehouseRequest(quantity: 10, locality: "SP", type: "MAIN_STORAGE"),
                        new CreateProductWarehouseRequest(quantity: 2,  locality: "RJ", type: "ECOMMERCE")
                    }
                )
            );
            await _controller.Create(new ApiVersion(1, 0), createModel);

            var editModel = new EditProductRequest(
                name: "UPDATED",
                inventory: new EditProductInventoryRequest
                (
                    warehouses: new EditProductWarehouseRequest[]
                    {
                        new EditProductWarehouseRequest(quantity: 15, locality: "SP", type: "MAIN_STORAGE"),
                        new EditProductWarehouseRequest(quantity: 3,  locality: "RJ", type: "ECOMMERCE"),
                        new EditProductWarehouseRequest(quantity: 2,  locality: "RJ", type: "ECOMMERCE")
                    }
                )

            );

            var actual = await Assert.ThrowsAsync<ValidationException>(() => _controller.Edit(sku: createModel.Sku, model: editModel));

            Assert.Contains(actual.Errors, x => x.ErrorMessage.Equals("The warehouse must be unique."));
            Assert.Contains(actual.Errors, x => x.PropertyName.Equals(nameof(CreateProductInventoryRequest.Warehouses)));
        }

        #endregion
    }
}
