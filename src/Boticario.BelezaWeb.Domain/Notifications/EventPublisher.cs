using System;

namespace Boticario.BelezaWeb.Domain.Notifications
{
	public static class EventPublisher
	{
		public static event EventHandler<NotificationEventArgs> RaiseNotificationEvent;

		public static void OnRaiseNotificationEvent(NotificationEventArgs notificationEventArgs)
		{
			var handler = RaiseNotificationEvent;
			handler?.Invoke(new object(), notificationEventArgs);
		}
	}
}
