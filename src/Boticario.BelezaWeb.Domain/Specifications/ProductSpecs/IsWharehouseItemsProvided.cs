using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Notifications;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsWharehouseItemsProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = product.Inventory?.Warehouses?.Count > 0;
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorWharehouseWasntProvided));
			return result;
		}
	}
}
