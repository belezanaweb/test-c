using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Extensions;
using Boticario.BelezaWeb.Domain.Notifications;
using System.Linq;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsWharehouseTypeProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = !product.Inventory.Warehouses.Any(w => w.Type.IsNullOrWhiteSpace());
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorWharehouseTypeWasntProvided));
			return result;
		}
	}
}
