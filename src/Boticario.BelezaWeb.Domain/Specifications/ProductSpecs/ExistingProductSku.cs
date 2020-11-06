using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Boticario.BelezaWeb.Domain.Notifications;
using System.Linq;

namespace Boticario.BelezaWeb.Domain.Specifications.ProductSpecs
{
	public class ExistingProductSku : ISpecification<Product>
	{
		private readonly IProductRepository _productRepository;

		public ExistingProductSku(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public bool IsSatisfiedBy(Product product)
		{
			var result = _productRepository
				.List(r => r.Sku == product.Sku)
				.FirstOrDefault();

			if (result?.Sku > 0)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(ProductMessages.ErrorSkuExisting));

			return !(result?.Sku > 0);
		}
	}
}
