using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using FluentValidation;

namespace BelezaNaWeb.Application.Commands.Products.Commom.Validators
{
    public sealed class InventoryDtoValidator : AbstractValidator<InventoryDto>
    {
        public InventoryDtoValidator()
        {
            RuleForEach(p => p.Warehouses)
                .SetValidator(new WarehouseDtoValidator())
                .When(p => p.Warehouses != null);
        }
    }
}
