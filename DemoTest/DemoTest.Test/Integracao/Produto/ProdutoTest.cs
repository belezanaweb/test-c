using DemoTest.AppService.Application.Produto.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoTest.Test.Integracao.Produto
{
    public class CustomerControllerTests
    {
        private readonly HttpClient _client;

        public CustomerControllerTests()
        {
            var testServer = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()                
                .UseEnvironment("Development"));

            _client = testServer.CreateClient();
        }

        /// <summary>
        /// Da uma carga com um produto
        /// </summary>
        /// <returns></returns>
        public async Task<ProdutoResponse> CadastroInicial()
        {
            // Arrange
            var request = new ProdutoRequest
            {
                Sku = 0,
                Name = "Professionnel Expert Absolut Repair Cortex",
                Inventory = new InventoryRequest()
                {
                    Warehouses = new List<WarehouseRequest>()
                }
            };

            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "ES", Quantity = 1, Type = "LOJA 01" });
            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "SP", Quantity = 2, Type = "LOJA 02" });

            var objRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(objRequest, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/produtos", content);
            var actualResult = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ProdutoResponse>(actualResult);
        }

        /// <summary>
        /// Teste de cadastro da API com OK
        /// </summary>
        /// <returns>OK</returns>
        [Fact]        
        public async Task Test_Cadastrar()
        {
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new ProdutoRequest
            {
                Sku = 0,
                Name = "Professionnel Expert Absolut Repair Cortex",
                Inventory = new InventoryRequest()
                {
                    Warehouses = new List<WarehouseRequest>()
                }
            };

            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "ES", Quantity = 1, Type = "LOJA 01" });
            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "SP", Quantity = 2, Type = "LOJA 02" });

            var objRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(objRequest, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/produtos", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de casatro da API com BadRequest
        /// </summary>
        /// <returns>BadRequest</returns>
        [Fact]
        public async Task Test_Cadastrar_BadRequest()
        {
            var produtoCadastrado = await CadastroInicial();

            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Arrange
            var request = new ProdutoRequest
            {
                Sku = produtoCadastrado.Sku,
                Name = "Professionnel Expert Absolut Repair Cortex",
                Inventory = new InventoryRequest()
                {
                    Warehouses = new List<WarehouseRequest>()
                }
            };

            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "ES", Quantity = 1, Type = "LOJA 01" });
            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "SP", Quantity = 2, Type = "LOJA 02" });

            var objRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(objRequest, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/produtos", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de atualizar da API com OK
        /// </summary>
        /// <returns>OK</returns>
        [Fact]
        public async Task Test_Atualizar()
        {
            await CadastroInicial();

            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new ProdutoRequest
            {
                Sku = 1,
                Name = "Camisa gola polo preta",
                Inventory = new InventoryRequest()
                {
                    Warehouses = new List<WarehouseRequest>()
                }
            };

            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "RS", Quantity = 2, Type = "LOJA 02" });
            request.Inventory.Warehouses.Add(new WarehouseRequest() { Locality = "DF", Quantity = 3, Type = "LOJA 03" });

            var objRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(objRequest, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/produtos", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de atualizar da API com BadRequest
        /// </summary>
        /// <returns>BadRequest</returns>
        [Fact]
        public async Task Test_Atualizar_BadRequest()
        {
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Arrange
            var request = new ProdutoRequest
            {
                Sku = 88,
                Name = "Produto não existe",
                Inventory = new InventoryRequest()
                {
                    Warehouses = new List<WarehouseRequest>()
                }
            };

            var objRequest = JsonConvert.SerializeObject(request);

            var content = new StringContent(objRequest, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/produtos", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de recuperar da API com OK
        /// </summary>
        /// <returns>OK</returns>
        [Fact]
        public async Task Test_Recuperar()
        {
            var produtoCadastrado = await CadastroInicial();

            var expectedStatusCode = HttpStatusCode.OK;

            // Act
            var response = await _client.GetAsync($"/api/produtos/{produtoCadastrado.Sku}");

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de recuperar da API com BadRequest
        /// </summary>
        /// <returns>BadRequest</returns>
        [Fact]
        public async Task Test_Recuperar_BadRequest()
        {
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await _client.GetAsync($"/api/produtos/99");

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de deletar da API com OK
        /// </summary>
        /// <returns>OK</returns>
        [Fact]
        public async Task Test_Deletar()
        {
            await CadastroInicial();

            var expectedStatusCode = HttpStatusCode.OK;

            // Act
            var response = await _client.DeleteAsync("/api/produtos/1");

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        /// <summary>
        /// Teste de deletar da API com BadRequest
        /// </summary>
        /// <returns>BadRequest</returns>
        [Fact]
        public async Task Test_Deletar_BadRequest()
        {
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await _client.DeleteAsync("/api/produtos/90");

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
