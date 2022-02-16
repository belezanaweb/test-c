using BelezaNaWeb.Application.Commands.Products.Commom.Validators;
using FluentValidation;

namespace BelezaNaWeb.Application.Commands.Products.Create
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Sku)
                .GreaterThan(0);

            RuleFor(p => p.Inventory)
                .SetValidator(new InventoryDtoValidator())
                .When(p => p.Inventory != null);
        }
    }
}
