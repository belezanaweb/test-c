using BelezaNaWeb.TestC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.TestC.Api.Data
{
    public class BdInMemory : IBdInMemory
    {
        public IList<Product> Products { get; } = new List<Product>();

        public BdInMemory()
            => DataSeeding();

        private void DataSeeding()
        {
            var product = new Product
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse>
                    {
                        new Warehouse
                        {
                            Locality = "SP",
                            Quantity = 12,
                            Type = Warehouse.TYPE_ECOMMERCE_VALUE,
                        },
                        new Warehouse
                        {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = Warehouse.TYPE_PHYSICAL_STORE_VALUE,
                        }
                    }
                }
            };

            this.Products.Add(product);
        }
    }
}
