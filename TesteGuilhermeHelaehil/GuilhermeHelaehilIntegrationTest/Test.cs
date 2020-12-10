using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Xunit;
using TesteGuilhermeHelaehil;
using TesteGuilhermeHelaehil.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Text.Json;

namespace GuilhermeHelaehilIntegrationTest
{
    [TestCaseOrderer("GuilhermeHelaehilIntegrationTest.Orderer", "XUnit.Project")]
    public class Test
    {
        private readonly HttpClient _client;

        public Test()
        {
            var server = new TestServer(
                    new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>()
                );
            _client = server.CreateClient();
        }

        //retorno de todos os produtos
        [Theory]
        [InlineData("GET")]
        public async Task Test1ProductGetAll(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/product/");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //criação de produto
        [Theory]
        [InlineData("POST")]
        public async Task Test2CreateProduct(string method)
        {
            //Arrange
            Product product = new Product {
                sku = 43264,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory(){
                    warehouses = new Warehouse[] {
                        new Warehouse{
                            locality = "SP",
                            quantity = 12,
                            type = "ECOMMERCE"
                        },
                        new Warehouse{
                            locality = "MOEMA",
                            quantity = 3,
                            type = "PHYSICAL_STORE"
                        }
                    }
                }
            };

            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/product/");
            request.Content = new StringContent(JsonSerializer.Serialize(product).ToString(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //recuperação de produto por SKU
        [Theory]
        [InlineData("GET", 43264)]
        public async Task Test3ProductGetBySku(string method, int sku)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/product/{sku}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //atualização de produto
        [Theory]
        [InlineData("PUT", 43264)]
        public async Task Test4UpdateProduct(string method, int sku)
        {
            //Arrange
            Product product = new Product
            {
                sku = 43264,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory()
                {
                    warehouses = new Warehouse[] {
                        new Warehouse{
                            locality = "SP",
                            quantity = 30, //Diferença no estoque
                            type = "ECOMMERCE"
                        },
                        new Warehouse{
                            locality = "MOEMA",
                            quantity = 1, //Diferença no estoque
                            type = "PHYSICAL_STORE"
                        }
                    }
                }
            };

            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/product/{sku}");
            request.Content = new StringContent(JsonSerializer.Serialize(product).ToString(), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //deleção de produto
        [Theory]
        [InlineData("DELETE", 43264)]
        public async Task Test5DeleteProduct(string method, int sku)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/product/{sku}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
