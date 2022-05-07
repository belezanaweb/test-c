using BelezaNaWeb.Entities;
using BelezaNaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.UnitTests
{
    internal class TestsUtil
    {
        public static Product GetMockProduct()
        {
            return new Product
            {
                sku = 43264,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                inventory = new Inventory
                {
                    warehouses = new List<Warehouse> {
                        new Warehouse {
                            locality = "SP",
                            quantity = 12,
                            type = WarehousesTypeEnum.ECOMMERCE
                        },
                        new Warehouse {
                            locality = "SP",
                            quantity = 3,
                            type = WarehousesTypeEnum.PHYSICAL_STORE
                        }
                    }
                }
            };
        }
    }
}
