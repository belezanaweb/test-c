using BlzWeb.Domain.StoreContext.Commands.ProductCommands.Inputs;
using BlzWeb.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System.Collections.Generic;

namespace BlzWeb.Domain.StoreContext.CustomerCommands.Inputs
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public List<WarehouseCommand> Warehouses { get; set; }

        public bool Valid()
        {

            AddNotifications(new ValidationContract()
                .IsLowerOrEqualsThan(0, Sku, "Sku", "O Sku Não pode ser 0")
                .IsNotNullOrEmpty(Name, "Name", "O nome do produto é obrigatório")
            );
            return IsValid;
        }
    }
}