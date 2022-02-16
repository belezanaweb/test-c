using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using BelezaNaWeb.Application.Commands.Products.Update;
using BelezaNaWeb.Domain.Entities.Products;
using System;

namespace BelezaNaWeb.Application.Commands.Products.Mappers
{
    public static class UpdateProductCommandMapper
    {
        public static Product ToEntity(this UpdateProductCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            Product product;

            product = new Product(command.Sku, command.Name);
            product.Inventory = new Inventory(command.Sku, product);

            if (command.Inventory != null)
                AddWarehouse(command.Inventory, product.Inventory);

            return product;
        }

        private static void AddWarehouse(InventoryDto command, Inventory inventory)
        {
            foreach (var warehouseDto in command.Warehouses)
            {
                var warehouse = new Warehouse(
                    warehouseDto.Locality,
                    warehouseDto.Quantity,
                    warehouseDto.Type,
                    inventory);

                inventory.AddWarehouse(warehouse);
            }
        }
    }
}
