using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModels;
using BelezaNaWeb.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BelezaNaWeb.Tests.Service
{
    public class ProductUnitTest : TestBase
    {
        private readonly IProductAppService productAppService;

        public ProductUnitTest()
        {
            productAppService = ServiceProvider.GetService<IProductAppService>();
        }


        [Fact]
        public void Test01_ShouldRegisterProduct()
        {
            productAppService.Register(new ProductViewModel()
            {
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Sku = 43264,
                Inventory = new InventoryViewModel()
                {
                    Warehouses = new System.Collections.Generic.List<WarehouseViewModel>
                    {
                        new WarehouseViewModel()
                        {
                            Locality = "SP",
                            Quantity = 12,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseViewModel()
                        {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            });

            Assert.True(true);
        }

        [Fact]
        public void Test02_ShouldThrowProductExistsException()
        {
            try
            {
                productAppService.Register(new ProductViewModel()
                {
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Sku = 43264,
                    Inventory = new InventoryViewModel()
                    {
                        Warehouses = new System.Collections.Generic.List<WarehouseViewModel>
                    {
                        new WarehouseViewModel()
                        {
                            Locality = "SP",
                            Quantity = 12,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseViewModel()
                        {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                    }
                });

                Assert.True(false);
            }
            catch(DomainException ex)
            {
                Assert.True(ex.Message == "Product 43264 already exists.");
            }
        }



        [Fact]
        public void Test03_ShouldNotFindProduct()
        {
            try
            {
                var product = productAppService.GetBySku(43265);
            }
            catch(DomainException ex)
            {
                Assert.True(ex.Message == "Product 43265 not found.");
            }
        }
    }
}
