using FluentValidation;
using Projeto.Domain.Models;
using Projeto.Domain.Resources;

namespace Projeto.Domain.Validations
{
    public class WarehouseValidation : AbstractValidator<Warehouse>
    {
        public WarehouseValidation()
        {
            ValidateProdutoSku();
            ValidateLocality();
            ValidateQuantity();
            ValidateType();
        }

        protected void ValidateProdutoSku()
        {
            RuleFor(c => c.ProdutoSku)
                .GreaterThan(0)
                    .WithMessage(WarehouseResource.ProdutoSkuRequired);
        }

        protected void ValidateLocality()
        {
            RuleFor(c => c.Locality)
                .NotEmpty()
                    .WithMessage(WarehouseResource.LocalityRequired)
                .MaximumLength(100)
                    .WithMessage(WarehouseResource.LocalityMaximumLength);
        }

        protected void ValidateQuantity()
        {
            RuleFor(c => c.Quantity)
                .Must(q => q >= 0)
                    .WithMessage(WarehouseResource.QuantityNegative);
        }

        protected void ValidateType()
        {
            RuleFor(c => c.Type)
                .NotEmpty()
                    .WithMessage(WarehouseResource.TypeRequired)
                .MaximumLength(15)
                    .WithMessage(WarehouseResource.TypeMaximumLength);
        }
    }
}
