using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Notifications;
using System.Linq;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsWharehouseQuantityProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = product.Inventory.Warehouses.All(w => w.Quantity != 0);
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorWharehouseQuantityWasntProvided));
			return result;
		}
	}
}
