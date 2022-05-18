using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.ViewModels;
using Belezanaweb.Application.Validators.Products;
using MediatR;

namespace Belezanaweb.Application.Products.Queries
{
    public class GetProductBySkuQuery : RequestBase<Response<ProductViewModel>>
    {
        public GetProductBySkuQuery(long sku)
        {
            Sku = sku;
        }

        public long Sku { get; }

        public override bool IsValid()
        {
            ValidationResult = new GetProductBySkuValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
