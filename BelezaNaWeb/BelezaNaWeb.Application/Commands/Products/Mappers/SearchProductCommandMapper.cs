using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using BelezaNaWeb.Application.Commands.Products.List;
using BelezaNaWeb.Domain.Entities.Products;

namespace BelezaNaWeb.Application.Commands.Products.Mappers
{
    public static class SearchProductCommandMapper
    {
        public static SearchProductCommandResult MapProduct(Product product)
        {
            var result = new SearchProductCommandResult
            {
                Sku = product.Sku,
                Name = product.Name,                
                Inventory = new InventoryDto()
            };

            foreach (var warehouse in product.Inventory.Warehouses)
            {
                var warehouseDto = new WarehouseDto()
                {
                    Locality = warehouse.Locality,
                    Quantity = warehouse.Quantity,
                    Type = warehouse.Type
                };

                result.Inventory.AddWarehouse(warehouseDto);
            }

            return result;
        }
    }
}
