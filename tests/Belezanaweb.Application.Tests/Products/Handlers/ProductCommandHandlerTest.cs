using AutoMapper;
using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Application.Products.DTOs;
using Belezanaweb.Application.Products.Handlers;
using Belezanaweb.Application.Products.Queries;
using Belezanaweb.Core.Enums;
using Belezanaweb.Core.Exceptions;
using Belezanaweb.Domain.Products.Enums;
using Belezanaweb.Domain.Products.Repositories;
using Belezanaweb.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Belezanaweb.Application.Tests
{
    public class Tests
    {
        private IServiceCollection _services;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _services = new ServiceCollection();
            IoC.Load(_services);
            var provider = _services.BuildServiceProvider();
            _productRepository = provider.GetRequiredService<IProductRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        [Test(Description = "Cria um novo produto sem problemas.")]
        public async Task CreateNewProduct()
        {
            var response = await CreateProductWithSkuAsync(12345678);
            Assert.True(response.Success);
        }

        [Test(Description = "Tenta criar um produto com SKU já existente, gerando BusinessException")]
        public async Task CreateNewProductWithSku()
        {
            var response = await CreateProductWithSkuAsync(888);
            Assert.True(response.Success);
            Assert.CatchAsync<BusinessException>(async () => await CreateProductWithSkuAsync(888));
        }

        [Test(Description = "Tenta criar um produto sem informar um SKU, gerando ValidatorException")]
        public void CreateNewProductWithoutSku()
        {
            Assert.CatchAsync<ValidatorException>(async () => await CreateProductWithSkuAsync(0));
        }

        [Test(Description = "Obtém o produto gravado sem problemas")]
        public async Task GetProductByValidSku()
        {
            var createResponse = await CreateProductWithSkuAsync(111);
            Assert.True(createResponse.Success);

            var request = new GetProductBySkuQuery(111);
            var queryHandler = new GetProductBySkuQueryHandler(_productRepository, _mapper);
            var response = await queryHandler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(response.Success);
            Assert.True(response.Data.IsMarketable);
            Assert.AreEqual(15, response.Data.Inventory.Quantity);
        }

        [Test(Description = "Tenta obter produto com SKU inexistente, gerando BusinessException")]
        public void GetProductByInvalidSku()
        {
            long sku = 1;
            var command = new GetProductBySkuQuery(sku);

            var handler = new GetProductBySkuQueryHandler(_productRepository, _mapper);
            Assert.CatchAsync<BusinessException>(async () => await handler.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test(Description = "Altera o estoque do produto cadastrado")]
        public async Task SetWarehouseQuantity()
        {
            var createResponse = await CreateProductWithSkuAsync(555);
            Assert.True(createResponse.Success);

            var command = GetCommand<AlterProductCommand>("AlterProductCommand");
            command.Sku = 555;
            var handler = new AlterProductCommandHandler(_productRepository, _mapper);
            var response = await handler.Handle(command, new System.Threading.CancellationToken());

            Assert.True(response.Success);
        }
        
        [Test(Description = "Cria um produto e logo exclúi")]
        public async Task DeleteProduct()
        {
            var response = await CreateProductWithSkuAsync(999);
            Assert.True(response.Success);

            var deleteCommand = new DeleteProductCommand(999);
            var deleteHandler = new DeleteProductCommandHandler(_productRepository);
            var deleteResponse = await deleteHandler.Handle(deleteCommand, new System.Threading.CancellationToken());
            Assert.True(deleteResponse.Success);
        }

        [Test(Description = "Tenta excluir um produto não existente, gerando BusinessException")]
        public void DeleteInvalidProduct()
        {
            var command = new DeleteProductCommand(987);
            var handler = new DeleteProductCommandHandler(_productRepository);
            Assert.CatchAsync<BusinessException>(async () => await handler.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test(Description = "Tenta alterar um produto não existente na base, gerando BusinessException")]
        public void TryToAlterInvalidProduct()
        {
            var command = GetCommand<AlterProductCommand>("AlterProductCommand");
            command.Sku = 12312;

            var handler = new AlterProductCommandHandler(_productRepository, _mapper);
            Assert.CatchAsync<BusinessException>(async () => await handler.Handle(command, new System.Threading.CancellationToken()));

        }

        private T GetCommand<T>(string fileName) where T : IRequestBase
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using TextReader file = File.OpenText(@$"../../../Resources/{fileName}.json");
            return (T)jsonSerializer.Deserialize(file, typeof(T));
        }

        private async Task<Response> CreateProductWithSkuAsync(long sku)
        {
            var command = GetCommand<CreateProductCommand>("CreateProductCommand");
            command.Sku = sku;
            var handler = new CreateProductCommandHandler(_productRepository, _mapper);
            return await handler.Handle(command, new System.Threading.CancellationToken());
        }
    }
}