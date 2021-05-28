using Inventory.Core.Notification;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Domain.Handlers
{
    class Notifiable<T> 
        : INotifiable<T>, 
          INotificationHandler<T>
        where T : INotification
    {
        public event Notify<T> Handle;

        public Task Notify(T notification, CancellationToken cancellationToken)
        {
            var evento = this.Handle;
            if (evento == null)
                return Task.CompletedTask;
            return evento(notification, cancellationToken);
        }

        Task INotificationHandler<T>.Handle(T notification, CancellationToken cancellationToken)
        {
            return Notify(notification, cancellationToken);
        }
    }
}
