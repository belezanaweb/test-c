using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Tests.GenerateData
{
    public static class GenerateProductData
    {
        public static List<Warehouses> CreateListWirehouseValid()
        {
            List<Warehouses> listWirehouseValid = new List<Warehouses>();
            Warehouses wirehouse1 = new Warehouses("JABAQUARA", 10, "ECOMMERCE");
            Warehouses wirehouse2 = new Warehouses("SÃO PAULO", 10, "PHYSICAL_STORE");

            listWirehouseValid.Add(wirehouse1);
            listWirehouseValid.Add(wirehouse2);

            return listWirehouseValid;
        }

        public static Inventory CreateInventoryValid()
        {
            Inventory inventoryValid = new Inventory();
            inventoryValid.Warehouses = new List<Warehouses>();
            inventoryValid.Warehouses = CreateListWirehouseValid();

            return inventoryValid;
        }

        public static Inventory CreateInventoryWithWarehouseNull()
        {
            Inventory inventoryWarehouseNull = new Inventory();
            inventoryWarehouseNull.Warehouses = null;

            return inventoryWarehouseNull;
        }

        public static Entities.Product CreateProductValid()
        {
            Entities.Product product = new Entities.Product(12345, "Produto teste", CreateInventoryValid());
            return product;
        }

        public static Entities.Product CreateProductWarehouseNullInvalid()
        {
            Entities.Product product = new Entities.Product(0, "", CreateInventoryWithWarehouseNull());
            return product;
        }
    }
}
