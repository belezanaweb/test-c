using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Notifications;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsSkuProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = product.Sku > 0;
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorSkuWasntProvided));
			return result;
		}
	}
}
