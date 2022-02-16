using System.Collections.Generic;

namespace BelezaNaWeb.BuildingBlocks.Notifications
{
    public interface INotificationContext
    {
        int ErrorCode { get; }

        bool HasNotifications { get; }

        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(Notification notification);

        void AddNotFound(string field, string message);

        void AddBadRequest(string field, string message);
    }
}
