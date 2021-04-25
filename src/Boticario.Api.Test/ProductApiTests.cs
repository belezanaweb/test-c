using Boticario.Api.Test.Configuration;
using Boticario.Api.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Boticario.Api.Test
{
    [TestCaseOrderer("Boticario.Api.Test.Configuration.PriorityOrderer", "Boticario.Api.Test")]
    public class ProductApiTests
    {
        #region Properties

        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly ProductViewModel productFake;

        #endregion

        #region Constructors

        public ProductApiTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            _client = _server.CreateClient();

            productFake = NewProduct();
        }

        #endregion

        #region Public Methods

        [Fact, TestPriority(1)]
        public async Task Product_Create_Ok()
        {
            // Arrange
            var productJson = JsonConvert.SerializeObject(productFake);
            var productContent = new StringContent(productJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Product/Create", productContent);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(2)]
        public async Task Product_Update_Ok()
        {
            // Arrange
            productFake.Name = "Shampoo Update";
            var productJson = JsonConvert.SerializeObject(productFake);
            var productContent = new StringContent(productJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/v1/Product/Update", productContent);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(3)]
        public async Task Product_GetAll_Ok()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/Product/GetAll");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(4)]
        public async Task Product_GetBySku_Ok()
        {
            // Act
            var sku = productFake.Sku;
            var response = await _client.GetAsync($"/api/v1/Product/GetBySku/{sku}");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(5)]
        public async Task Product_Delete_Ok()
        {
            // Act
            var sku = productFake.Sku;
            var response = await _client.DeleteAsync($"/api/v1/Product/DeleteBySku/{sku}");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(6)]
        public async Task Product_Create_WithOutSku()
        {
            // Arrange
            var productJson = JsonConvert.SerializeObject(NewProductWithOutSku());
            var productContent = new StringContent(productJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Product/Create", productContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ResponseViewModel>(responseString);

            // Assert
            Assert.False(responseObject.Success);
            Assert.Contains(responseObject.Errors, x => x.Contains("Sku deve ser um valor entre 1 e 4294967295"));
        }

        [Fact, TestPriority(7)]
        public async Task Product_Create_WithOutName()
        {
            // Arrange
            var productJson = JsonConvert.SerializeObject(NewProductWithOutName());
            var productContent = new StringContent(productJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Product/Create", productContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ResponseViewModel>(responseString);

            // Assert
            Assert.False(responseObject.Success);
            Assert.Contains(responseObject.Errors, x => x.Contains("Campo Name é obrigatório"));
        }

        #endregion

        #region Private Methods

        private static ProductViewModel NewProduct()
        {
            return new ProductViewModel
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new InventoryViewModel
                {
                    Warehouses = new List<WarehouseViewModel> {
                        new WarehouseViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        new WarehouseViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        private static ProductViewModel NewProductWithOutSku()
        {
            return new ProductViewModel
            {
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new InventoryViewModel
                {
                    Warehouses = new List<WarehouseViewModel> {
                        new WarehouseViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        new WarehouseViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        private static ProductViewModel NewProductWithOutName()
        {
            return new ProductViewModel
            {
                Sku = 43264,
                Inventory = new InventoryViewModel
                {
                    Warehouses = new List<WarehouseViewModel> {
                        new WarehouseViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        new WarehouseViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        #endregion
    }
}