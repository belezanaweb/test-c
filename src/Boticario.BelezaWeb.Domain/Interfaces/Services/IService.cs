using Boticario.BelezaWeb.Domain.Notifications;

namespace Boticario.BelezaWeb.Domain.Interfaces.Services
{
	public abstract class Service<TEntity> : NotificationService
	{
		public abstract Notification Validate(TEntity entity, bool isUpdate = false);

		public void HandleNotificationEvent(object sender, NotificationEventArgs notificationEventArgs)
		{
			Notifier.Errors.Add(notificationEventArgs.Message);
		}
	}
}
