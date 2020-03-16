using BelezaNaWeb.Shared.Commands;
using Flunt.Notifications;

namespace BelezaNaWeb.Domain.Commands.RemoveProductCommand.Input
{
    public class RemoveProductCommand : Notifiable, ICommand
    {

        public int sku { get; set; }
        public bool valid() {
            throw new System.NotImplementedException();
        }
    }
}
