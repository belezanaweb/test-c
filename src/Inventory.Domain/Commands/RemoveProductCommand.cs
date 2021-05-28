using Inventory.Core;
using System.Linq;

namespace Inventory.Domain.Commands
{
    public class RemoveProductCommand : ValidatableCommand
    {
        public static explicit operator Core.Product(RemoveProductCommand command)
        {
            return command.Product;
        }

        private Product originalProduct;

        public RemoveProductCommand(RemoveProductCommand command, Core.Product originalProduct)
            : this(command.Sku)
        {
            command.Product = originalProduct;
            this.originalProduct = originalProduct;
        }

        public RemoveProductCommand(int sku)
        {
            this.Sku = sku;
        }

        public int Sku { get; }

        public Core.Product Product { get; private set; }

        public override bool EhValido()
        {
            this.notifications.Clear();
            if (originalProduct == null)
                base.notifications.Add("sku:notfound", $"The sku {this.Sku} was not found");
            return !notifications.Any();
        }
    }
}
