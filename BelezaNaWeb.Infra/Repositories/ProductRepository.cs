using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Queries;
using BelezaNaWeb.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Infra.Repositories {
    public class ProductRepository : IProductRepository {
        //Os produtos podem ficar em memória, não é necessário persistir os dados
        List<Product> products = new List<Product>();

        public bool checkSkuExists(int sku) {
            var product = this.products.FirstOrDefault(x => x.sku == sku);
            return !(product == null);
        }

        public void save(Product product) {
            this.products.Add(product);
        }

        public bool update(Product product) {
            //Como os dados não estão sendo persistidos, optei por remover o item e adicionar novo no update
            this.products.RemoveAll(p => p.sku == product.sku);
            this.products.Add(product);
            return true;
        }

        public ProductResult getProduct(int sku) {
            var product = this.products.FirstOrDefault(p => p.sku == sku);
            var inventoryResult = new InventoryResult();
            if (product != null)
            {
                foreach (var warewouse in product.inventory.warehouses)
                {
                    inventoryResult.warehouses.Add(getWarehouseResult(warewouse));
                }
                inventoryResult.quantity = product.inventory.quantity;
                return getProductResult(product, inventoryResult);
            } else
              return null;

        }

        public List<ProductResult> getAll() {
            var productsResult = new List<ProductResult>();
            
            foreach (var product in this.products) {
                var inventoryResult = new InventoryResult();
                foreach (var warewouse in product.inventory.warehouses) {
                    inventoryResult.warehouses.Add(getWarehouseResult(warewouse));
                }
                inventoryResult.quantity = product.inventory.quantity;
                productsResult.Add(getProductResult(product, inventoryResult));
            }
            return productsResult;
        }

        public bool delete(int sku) {
            return this.products.RemoveAll(p => p.sku == sku) > 0;
        }

        private WarehouseResult getWarehouseResult(Warehouse warewouse) => new WarehouseResult {
            locality = warewouse.locality,
            quantity = warewouse.quantity,
            type = warewouse.type.ToString()
        };

        private static ProductResult getProductResult(Product product, InventoryResult inventoryResult) => new ProductResult {
            sku = product.sku,
            name = product.name,
            inventory = inventoryResult,
            isMarketable = product.isMarketable
        };
    }
}
