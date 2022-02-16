using FluentValidation;

namespace BelezaNaWeb.Application.Commands.Products.Delete
{
    public sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Sku)
                .GreaterThan(0);
        }
    }
}
