using Moq;
using Projeto.Domain.Interfaces;
using Projeto.Domain.Models;
using Projeto.Domain.Repositories;
using Projeto.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Domain.UnitTest.Services
{
    public class ProdutoServiceTest
    {
        private readonly Mock<ITelemetryService> _telemetryService;
        private readonly Mock<INotificationService> _notificationService;
        private readonly Mock<IProdutoRepository> _produtoRepository;
        private readonly Mock<IWarehouseService> _warehouseService;

        public ProdutoServiceTest()
        {
            _telemetryService = new Mock<ITelemetryService>();
            _notificationService = new Mock<INotificationService>();
            _produtoRepository = new Mock<IProdutoRepository>();
            _warehouseService = new Mock<IWarehouseService>();
        }

        // TODO: implementar demais testes para aumentar a cobertura de testes do projeto
        // para simplificar o projeto, vou deixar apenas os testes abaixo

        [Fact(DisplayName = "Deve calcular o inventário do produto e retornar o produto como disponivel")]
        public async Task CalcularInvetarioProdutoDisponivel()
        {
            var expected = 4;
            var quantity = 2;

            var produto = new Produto() { Sku = 1, Nome = "Teste" };
            var warehouse = new List<Warehouse>()
            {
                new Warehouse() {ProdutoSku = 1, Locality = "SP", Quantity = quantity, Type = "PHYSICAL_STORE" },
                new Warehouse() {ProdutoSku = 1, Locality = "RJ", Quantity = quantity, Type = "ECOMMERCE" },
            };

            _produtoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Produto>(produto));
            _warehouseService.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<IEnumerable<Warehouse>>(warehouse));

            var produtoService = new ProdutoService(_telemetryService.Object, _produtoRepository.Object, _notificationService.Object, _warehouseService.Object);
            var result = await produtoService.CalculteInventory(1).ConfigureAwait(false);

            Assert.Equal(expected, result.Quantity);
            Assert.True(result.IsMarketable);
        }

        [Fact(DisplayName = "Deve calcular o inventário do produto e retornar o produto como indisponivel")]
        public async Task CalcularInvetarioProdutoIndisponivel()
        {
            var expected = 0;
            var quantity = 0;

            var produto = new Produto() { Sku = 1, Nome = "Teste" };
            var warehouse = new List<Warehouse>()
            {
                new Warehouse() {ProdutoSku = 1, Locality = "SP", Quantity = quantity, Type = "PHYSICAL_STORE" },
                new Warehouse() {ProdutoSku = 1, Locality = "RJ", Quantity = quantity, Type = "ECOMMERCE" },
            };

            _produtoRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Produto>(produto));
            _warehouseService.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<IEnumerable<Warehouse>>(warehouse));

            var produtoService = new ProdutoService(_telemetryService.Object, _produtoRepository.Object, _notificationService.Object, _warehouseService.Object);
            var result = await produtoService.CalculteInventory(1).ConfigureAwait(false);

            Assert.Equal(expected, result.Quantity);
            Assert.False(result.IsMarketable);
        }
    }
}
