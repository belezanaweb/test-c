using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using FluentValidation;

namespace BelezaNaWeb.Application.Commands.Products.Commom.Validators
{
    public sealed class WarehouseDtoValidator : AbstractValidator<WarehouseDto>
    {
        public WarehouseDtoValidator()
        {
            RuleFor(p => p.Quantity)
                .GreaterThan(0);
        }
    }
}
