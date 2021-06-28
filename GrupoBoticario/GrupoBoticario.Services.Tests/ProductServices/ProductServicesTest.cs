using GrupoBoticario.Domain.Interfaces;
using GrupoBoticario.Domain.IRepositories;
using GrupoBoticario.Domain.Payload.Product;
using GrupoBoticario.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GrupoBoticario.Services.Tests.ProductServices
{
    public class ProductServicesTest
    {
        private Mock<IProductRepository> _mockProductRepository = new Mock<IProductRepository>();
        private Mock<ILogger<ProductService>> _mockLogger = new Mock<ILogger<ProductService>>();

       [Fact]
        public async Task Test_AddProduct_Payload_NuloAsync() 
        {

            var service = new ProductService(null, null, null, _mockLogger.Object);
            
            var @action = new Func<Task>(() => service.AddProduct(null));

            await Assert.ThrowsAsync<InvalidOperationException>(@action);
        }

        [Fact]
        public async Task Test_AddProduct_Payload_Vazio()
        {

            var service = new ProductService(null, null, null, _mockLogger.Object);

            var @action = new Func<Task>(() => service.AddProduct(new List<ProductSavePayload>()));

            await Assert.ThrowsAsync<InvalidOperationException>(@action);
        }       

        [Fact]
        public async Task Test_AddProduct_Payload_Sku_Cadastrado_Valido()
        {
            _mockProductRepository.Setup(x => x.AnyAsync(x => It.IsAny<bool>())).ReturnsAsync(false);

            var service = new ProductService(_mockProductRepository.Object, null, null, _mockLogger.Object);

            var payloads = new List<ProductSavePayload>
            {
                new ProductSavePayload
                {
                   Name = "Produto cadastrado"
                }
            };           

            await service.AddProduct(payloads);
        }
    }
}
