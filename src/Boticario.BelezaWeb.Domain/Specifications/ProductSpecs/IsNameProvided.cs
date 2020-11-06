using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Extensions;
using Boticario.BelezaWeb.Domain.Notifications;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class IsNameProvided : ISpecification<Product>
	{
		public bool IsSatisfiedBy(Product product)
		{
			var result = !product.Name.IsNullOrWhiteSpace();
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorNameWasntProvided));
			return result;
		}
	}
}
