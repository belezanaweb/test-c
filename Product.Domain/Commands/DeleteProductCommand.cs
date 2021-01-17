using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Product.Domain.Commands.Contracts;
using Product.Domain.Entities;

namespace Product.Domain.Commands
{
    public class DeleteProductCommand : Notifiable, ICommand
    {
        public DeleteProductCommand()
        {
        }

        public DeleteProductCommand(int sku)
        {
            Sku = sku;            
        }

        public int Sku { get; set; } 

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Sku, 0, "Sku", "Por favor verifique o Sku")                    
            );
        }
    }
}
