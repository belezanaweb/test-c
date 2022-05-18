using Belezanaweb.Application.Products.Commands;
using FluentValidation;

namespace Belezanaweb.Application.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(p => p.Sku)
                .NotEmpty()
                .WithMessage("Sku não pode ser nulo.");
        }
    }
}
