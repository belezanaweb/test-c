using Belezanaweb.Application.Products.Queries;
using FluentValidation;

namespace Belezanaweb.Application.Validators.Products
{
    public class GetProductBySkuValidator : AbstractValidator<GetProductBySkuQuery>
    {
        public GetProductBySkuValidator()
        {
            RuleFor(p => p.Sku)
                .NotEmpty()
                .WithMessage("Sku não pode ser nulo.");
        }
    }
}
