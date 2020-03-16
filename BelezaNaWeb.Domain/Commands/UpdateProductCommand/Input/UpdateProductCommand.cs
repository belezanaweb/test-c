using BelezaNaWeb.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BelezaNaWeb.Domain.Commands.UpdateProductCommand.Input
{
    public class UpdateProductCommand : Notifiable, ICommand {
        public int sku { get; set; }
        public string name { get; set; }
        
        public InventoryCommand inventory { get; set; } = new InventoryCommand();

        public bool valid()
        {
            var validator = new Contract()
                                .Requires()
                                .IsNotNullOrEmpty(name, "string", "O Campo nome é obrigatorio")
                                .IsBetween(sku, 1, 999999, "int", "O Campo SKU deve ser maior de zero");
            AddNotifications(validator.Notifications);
            return validator.Valid;

        }
    }

    public class WarehouseCommand {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
    public class InventoryCommand {
        public WarehouseCommand[] warehouses { get; set; } = new WarehouseCommand[0];
    }
}
