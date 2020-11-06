using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Extensions;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Boticario.BelezaWeb.Domain.Specifications.ProductSpecs;

namespace Boticario.BelezaWeb.Domain.Validators.ProductValidators
{
	public class ProductValidator : IValidator
	{
		private readonly Product _product;
		private readonly IProductRepository _productRepository;

		public ProductValidator(Product product, IProductRepository productRepository)
		{
			_product = product;
			_productRepository = productRepository;
		}

		public bool Validate()
		{
			var rule =
				new IsNameProvided()
					.And(new IsSkuProvided())
					.And(new IsInventoryProvided())
					.And(new IsWharehouseItemsProvided())
					.And(new IsWharehouseLocalityProvided())
					.And(new IsWharehouseTypeProvided())
					.And(new ExistingProductSku(_productRepository));

			return rule.IsSatisfiedBy(_product);
		}
	}
}
