using BelezaNaWeb.Application.Commands.Products.Commom.Validators;
using FluentValidation;

namespace BelezaNaWeb.Application.Commands.Products.Update
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Sku)
                .GreaterThan(0);

            RuleFor(p => p.Inventory)
                .SetValidator(new InventoryDtoValidator())
                .When(p => p.Inventory != null);
        }
    }
}
