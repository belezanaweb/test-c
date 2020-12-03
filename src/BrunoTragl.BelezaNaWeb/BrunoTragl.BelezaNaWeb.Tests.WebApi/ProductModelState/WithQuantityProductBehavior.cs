using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Base;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using System.Collections.Generic;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState
{
    public class WithQuantityProductBehavior : ProductBase
    {
        protected override void CreateProduct()
        {
            Product = new ProductModel  
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new InventoryModel
                {
                    Warehouses = new List<WarehouseModel>()
                    {
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 12,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseModel
                        {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = "PHYSICAL_STORE"
                        }
                    }
                }
            };
        }
    }
}
