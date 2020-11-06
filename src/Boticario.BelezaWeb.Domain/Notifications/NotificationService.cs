namespace Boticario.BelezaWeb.Domain.Notifications
{
	public abstract class NotificationService
	{
		public readonly Notification Notifier;

		protected NotificationService()
		{
			Notifier = new Notification();
		}
	}
}
