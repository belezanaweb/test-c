using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Core.Notification
{
    public delegate Task Notify<T>(T notification, CancellationToken cancellationToken);

    public interface INotifiable<T>
    {
        event Notify<T> Handle;

        Task Notify(T notification, CancellationToken cancellationToken);
    }
}
