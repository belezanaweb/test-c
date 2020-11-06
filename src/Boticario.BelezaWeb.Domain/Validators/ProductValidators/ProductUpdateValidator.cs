using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Extensions;
using Boticario.BelezaWeb.Domain.Specifications.ProductSpecs;

namespace Boticario.BelezaWeb.Domain.Validators.ProductValidators
{
	public class ProductUpdateValidator : IValidator
	{
		private readonly Product _product;

		public ProductUpdateValidator(Product product)
		{
			_product = product;
		}

		public bool Validate()
		{
			var rule =
				new IsNameProvided()
					.And(new IsSkuProvided())
					.And(new IsInventoryProvided())
					.And(new IsWharehouseItemsProvided())
					.And(new IsWharehouseLocalityProvided())
					.And(new IsWharehouseTypeProvided());

			return rule.IsSatisfiedBy(_product);
		}
	}
}
