using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.BuildingBlocks.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public bool HasNotifications => _notifications.Any();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public int ErrorCode { get; private set; }

        public void AddNotFound(string field, string message)
        {
            AddInternNotification(field, "NotFound", message);
            UpdateErrorCodeToNotFound();
        }

        public void AddBadRequest(string field, string message)
        {
            AddInternNotification(field, "BadRequest", message);
            UpdateErrorCodeToBadRequest();
        }

        public void AddNotification(Notification notification) => _notifications.Add(notification);

        protected void AddInternNotification(string field, string rule, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            _notifications.Add(Notification.CreateWithStatusCode(field, rule, message));
        }

        private void UpdateErrorCodeToBadRequest() => ErrorCode = StatusCodes.Status400BadRequest;

        private void UpdateErrorCodeToNotFound() => ErrorCode = StatusCodes.Status404NotFound;
    }
}
