using AutoMapper;
using BelezaNaWebApi.Controllers;
using BelezaNaWebApi.Model;
using BelezaNaWebApplication.Services;
using BelezaNaWebDomain;
using BelezaNaWebDomain.Repositories;
using BelezaNaWebDomain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BelezaNaWebTest
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly IMapper _mapper;
        private List<Product> _mockProducts;

        public ProductControllerTests()
        {
            _mapper = AutoMapperTest.GetMapper();

            _mockProducts = new List<Product>()
            {
                new Product()
                {
                    SKU = 12345,
                    Name = "Produto 1",
                    Inventory = null
                },
                new Product()
                {
                    SKU = 54321,
                    Name = "Produto 2",
                    Inventory = null
                }
            };
        }

        [Fact]
        public async Task Retrieve_GetAllProducts_Sucess()
        {
            var productController = new ProductController(_productServiceMock.Object, _mapper);

            _productServiceMock.Setup<Task<IEnumerable<Product>>>(x => x.ListAsync())
                    .Returns(Task.FromResult<IEnumerable<Product>>(_mockProducts));

            var response = await productController.Get();

            Assert.NotNull(response);

            var resultOK = response.Result as OkObjectResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);

            IList<ProductModel> enumerable = (resultOK.Value as IList<ProductModel>);
            Assert.Equal(_mockProducts.Count, enumerable.Count);
        }

        [Fact]
        public async Task Retrieve_GetWithId_Sucess()
        {
            var productController = new ProductController(_productServiceMock.Object, _mapper);

            long sku = 12345;

            _productServiceMock.Setup<Task<Product>>(x => x.GetProductAsync(sku))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == sku)));

            var response = await productController.Get(sku);
            var resultOK = response as OkObjectResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);

            ProductModel objResult = resultOK.Value as ProductModel;
            Assert.Equal(sku, objResult.SKU);
        }

        [Fact]
        public void Post_CreateNewProduct_Sucess()
        {
            var productController = new ProductController(_productServiceMock.Object, _mapper);

            var productModel = new ProductModel()
            {
                SKU = 99999,
                Name = "Novo Produto"
            };

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(productModel.SKU.Value))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == productModel.SKU)));

            var entity = _mapper.Map<Product>(productModel);

            var response = productController.Post(productModel);
            var resultOK = response as OkResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);
        }

        [Fact]
        public void Post_CreateNewProduct_Error_Duplicate_BadRequest()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            var productModel = new ProductModel()
            {
                SKU = 12345,
                Name = "Novo Produto"
            };

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(productModel.SKU.Value))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == productModel.SKU)));

            var response = productController.Post(productModel);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_UpdateProduct_Error_BadRequest()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            long sku = 123456;

            var productModel = new ProductModel()
            {
                SKU = 12345,
                Name = "Produto Alterado!"
            };

            var response = productController.Put(sku, productModel);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_UpdateProduct_Error_NotFound_BadRequest()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            var productModel = new ProductModel()
            {
                SKU = 123456,
                Name = "Produto Alterado!"
            };

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(productModel.SKU.Value))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == productModel.SKU)));

            var response = productController.Put(productModel.SKU.Value, productModel);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_UpdateProduct_Sucess()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            var productModel = new ProductModel()
            {
                SKU = 12345,
                Name = "Produto Alterado!"
            };

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(productModel.SKU.Value))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == productModel.SKU)));

            var response = productController.Put(productModel.SKU.Value, productModel);
            var result = response as OkResult;

            Assert.NotNull(result);

            Assert.Equal(200, result.StatusCode);

            var productModelAltered = _mockProducts.FirstOrDefault(x => x.SKU == productModel.SKU);

            Assert.Equal(productModel.Name, productModelAltered.Name);
        }

        [Fact]
        public void Delete_DeleteProduct_Sucess()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            long sku = 12345;

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(sku))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == sku)));

            var response = productController.Delete(sku);
            var result = response as OkResult;

            Assert.NotNull(result);

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_DeleteProduct_NotFound_BadRequest()
        {
            var productController = new ProductController(new ProductService(_productRepositoryMock.Object), _mapper);

            long sku = 9999;

            _productRepositoryMock.Setup<Task<Product>>(x => x.FindByIdAsync(sku))
                    .Returns(Task.FromResult<Product>(_mockProducts.FirstOrDefault(x => x.SKU == sku)));

            var response = productController.Delete(sku);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }
    }
}