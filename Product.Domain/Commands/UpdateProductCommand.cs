using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Product.Domain.Commands.Contracts;
using Product.Domain.Entities;

namespace Product.Domain.Commands
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public UpdateProductCommand()
        {
        }

        public UpdateProductCommand(int sku, string name, Inventory inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = new Inventory();
            Inventory = inventory;
        }

        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Sku, 0, "Sku", "Por favor verifique o Sku")
                    .HasMinLen(Name, 3, "Name", "Por favor descreva melhor o nome desse produto")
                    .IsNotNull(Inventory, "Inventory", "Por favor adicione um inventory para salvar esse produto")
                    .IsNotNull(Inventory?.Warehouses, "Warehouses", "Por favor adicione um warehouse para salvar esse produto")
            );
        }
    }
}
