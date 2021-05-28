using Inventory.Core;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Domain.Commands
{
    public class UpdateProductCommand : ValidatableCommand
    {
        public static explicit operator Product(UpdateProductCommand command)
        {
            if (command.Inventory != null)
                command.Inventory.Sku = command.Sku;
            if (command?.Inventory.Warehouses != null)
                foreach (var item in command.Inventory.Warehouses)
                    item.Sku = command.Sku;
            var product = new Product(command.Sku, command.Name, command.Inventory, command.IsMarketable);
            product.CalculateInventory();
            return product;
        }
        
        private IQueryable<Product> originalProduct;

        public UpdateProductCommand()
        {

        }

        public UpdateProductCommand(long sku, string name, Core.Inventory inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        public UpdateProductCommand(UpdateProductCommand command, IQueryable<Product> originalProduct)
            : this(command.Sku, command.Name, command.Inventory)
        {
            this.originalProduct = originalProduct;
        }

        public long Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public Core.Inventory Inventory { get; set; }

        public override bool EhValido()
        {
            this.notifications.Clear();
            if (!originalProduct.Any())
                base.notifications.Add("sku:notfound", $"The sku {this.Sku} was not found");
            if (Sku.Equals(0))
                base.notifications.Add("sku:invalid", "Sku can not be 0");
            if (string.IsNullOrEmpty(this.Name))
                base.notifications.Add("name:invalid", "Name can not be null or empty");
            var list = new List<Core.Warehouse>(this.Inventory.Warehouses);
            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[i].Locality))
                    base.notifications.Add($"Inventory.Warehouses[{i}].name:invalid", $"The Warehouse name in position {i} can not be null or empty");
                if (string.IsNullOrEmpty(list[i].Type))
                    base.notifications.Add($"Inventory.Warehouses[{i}].type:invalid", $"The Warehouse type in position {i} can not be null or empty");
            }
            return !notifications.Any();
        }
    }
}
