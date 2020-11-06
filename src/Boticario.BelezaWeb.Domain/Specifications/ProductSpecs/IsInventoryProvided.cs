using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Notifications;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsInventoryProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = product.Inventory != null;
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorInventoryWasntProvided));
			return result;
		}
	}
}
