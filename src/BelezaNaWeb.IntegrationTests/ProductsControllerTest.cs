using BelezaNaWeb.API.Dtos.Inventory;
using BelezaNaWeb.API.Dtos.Product;
using BelezaNaWeb.API.Dtos.WareHouse;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BelezaNaWeb.IntegrationTests
{
    public class ProductsControllerTest
    {
        [Fact]
        public async Task GetAllProducts()
        {
            using (var client = new Provider().Client)
            {
                var response = await client.GetAsync("/api/Product");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task CreateProduct_Success()
        {
            using (var provider = new Provider())
            {
                provider.ClearTables();

                var productDto = new CreateProductDto()
                {
                    Sku = 43265,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api/Product")
                {
                    Content = content
                };

                var resultPost = await provider.Client.SendAsync(postRequest);
                var resultGet = await provider.Client.GetAsync($"/api/Product/{productDto.Sku}");

                var resultContent = await resultGet.Content.ReadAsStringAsync();
                var resultPostData = JsonConvert.DeserializeObject<ProductDto>(resultContent);

                resultPostData.IsMarketable.Should().Be(true);
                resultPostData.Inventory.Quantity.Should().Be(15);

                resultPost.StatusCode.Should().Be(HttpStatusCode.OK);
                resultGet.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task CreateProduct_Fail()
        {
            using (var provider = new Provider())
            {
                provider.ClearTables();
                provider.FixtureCreateTest();

                var productDto = new CreateProductDto()
                {
                    Sku = 66666,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api/Product")
                {
                    Content = content
                };

                var result = await provider.Client.SendAsync(postRequest);

                result.Content.ReadAsStringAsync().Result.Should().Be("O produto de SKU 66666 já existe na base.");
                result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            }
        }
        
        [Fact]
        public async Task CreateProduct_BadRequest()
        {
            using (var provider = new Provider())
            {
                var productDto = new CreateProductDto()
                {
                    Sku = 66666,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = null
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api/Product")
                {
                    Content = content
                };

                var result = await provider.Client.SendAsync(postRequest);

                result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task UpdateProduct_Success()
        {
            using (var provider = new Provider())
            {
                var sku = 66666;
                provider.ClearTables();
                provider.FixtureCreateTest();

                var productDto = new UpdateProductDto()
                {
                    Name = "Teste",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var putRequest = new HttpRequestMessage(method: HttpMethod.Put, requestUri: $"/api/Product/{sku}")
                {
                    Content = content
                };

                var resultPost = await provider.Client.SendAsync(putRequest);
                var resultGet = await provider.Client.GetAsync($"/api/Product/{sku}");

                var resultContent = await resultGet.Content.ReadAsStringAsync();
                var resultPostData = JsonConvert.DeserializeObject<ProductDto>(resultContent);

                resultPostData.IsMarketable.Should().Be(false);
                resultPostData.Inventory.Quantity.Should().Be(0);
                resultPostData.Name.Should().Be("Teste");

                resultPost.StatusCode.Should().Be(HttpStatusCode.OK);
                resultGet.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task UpdateProduct_Fail()
        {
            using (var provider = new Provider())
            {
                var sku = 55555;
                provider.ClearTables();
                provider.FixtureCreateTest();

                var productDto = new UpdateProductDto()
                {
                    Name = "Teste",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var putRequest = new HttpRequestMessage(method: HttpMethod.Put, requestUri: $"/api/Product/{sku}")
                {
                    Content = content
                };

                var result = await provider.Client.SendAsync(putRequest);

                result.Content.ReadAsStringAsync().Result.Should().Be($"O produto de SKU {sku} não foi encontrado.");
                result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            }
        }

        [Fact]
        public async Task UpdateProduct_BadRequest()
        {
            var sku = 66666;
            using (var provider = new Provider())
            {
                var productDto = new UpdateProductDto()
                {
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = null
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var putRequest = new HttpRequestMessage(method: HttpMethod.Put, requestUri: $"/api/Product/{sku}")
                {
                    Content = content
                };

                var result = await provider.Client.SendAsync(putRequest);

                result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task DeleteProduct_Success()
        {
            using (var provider = new Provider())
            {
                var sku = 66666;
                provider.ClearTables();
                provider.FixtureCreateTest();

                var deleteRequest = new HttpRequestMessage(method: HttpMethod.Delete, requestUri: $"/api/Product/{sku}");

                var result = await provider.Client.SendAsync(deleteRequest);

                result.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    
        [Fact]
        public async Task DeleteProduct_Fail()
        {
            using (var provider = new Provider())
            {
                var sku = 55555;
                provider.ClearTables();

                var deleteRequest = new HttpRequestMessage(method: HttpMethod.Delete, requestUri: $"/api/Product/{sku}");

                var result = await provider.Client.SendAsync(deleteRequest);

                result.Content.ReadAsStringAsync().Result.Should().Be($"O produto de SKU {sku} não foi encontrado.");
                result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            }
        }


        [Fact]
        public async Task Product_Marketable()
        {
            using (var provider = new Provider())
            {
                provider.ClearTables();

                var productDto = new CreateProductDto()
                {
                    Sku = 43265,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api/Product")
                {
                    Content = content
                };

                var resultPost = await provider.Client.SendAsync(postRequest);
                var resultGet = await provider.Client.GetAsync($"/api/Product/{productDto.Sku}");

                var resultContent = await resultGet.Content.ReadAsStringAsync();
                var resultPostData = JsonConvert.DeserializeObject<ProductDto>(resultContent);

                resultPostData.IsMarketable.Should().Be(true);
                resultPostData.Inventory.Quantity.Should().Be(15);

                resultPost.StatusCode.Should().Be(HttpStatusCode.OK);
                resultGet.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }


        [Fact]
        public async Task Product_NotMarketable()
        {
            using (var provider = new Provider())
            {
                provider.ClearTables();

                var productDto = new CreateProductDto()
                {
                    Sku = 43265,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new CreateInventoryDto()
                    {
                        WareHouses = new List<WareHouseDto>() {
                                                             new WareHouseDto() { Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                                                             new WareHouseDto() { Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }}
                    }
                };
                var json = JsonConvert.SerializeObject(productDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var postRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api/Product")
                {
                    Content = content
                };

                var resultPost = await provider.Client.SendAsync(postRequest);
                var resultGet = await provider.Client.GetAsync($"/api/Product/{productDto.Sku}");

                var resultContent = await resultGet.Content.ReadAsStringAsync();
                var resultPostData = JsonConvert.DeserializeObject<ProductDto>(resultContent);

                resultPostData.IsMarketable.Should().Be(false);
                resultPostData.Inventory.Quantity.Should().Be(0);

                resultPost.StatusCode.Should().Be(HttpStatusCode.OK);
                resultGet.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
