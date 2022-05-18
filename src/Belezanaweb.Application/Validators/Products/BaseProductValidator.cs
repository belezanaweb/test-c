using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Application.Products.DTOs;
using Belezanaweb.Core.Enums;
using Belezanaweb.Domain.Products.Enums;
using FluentValidation;
using System;
using System.Linq;

namespace Belezanaweb.Application.Validators.Products
{
    public abstract class BaseProductValidator : AbstractValidator<BaseProductCommand>
    {
        public BaseProductValidator()
        {
            RuleFor(p => p.Sku)
                .NotEmpty()
                .WithMessage("Sku não pode ser nulo.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Nome precisa de um valor.");

            RuleFor(p => p.Inventory)
                .NotEmpty()
                .WithMessage("O produto precisa de inventário.");

            RuleForEach(p => p.Inventory.Warehouses)
                .SetValidator(new WarehouseValidator());
        }
    }

    class WarehouseValidator : AbstractValidator<WarehouseDTO>
    {
        public WarehouseValidator()
        {
            RuleFor(w => w.Locality)
                .NotEmpty()
                .WithMessage("A localidade do warehouse deve ser informada.");

            RuleFor(w => w.Type)
                .NotEmpty()
                .WithMessage("O tipo do warehouse deve ser informado.")
                .Must(IsOfTypeWarehouseType)
                .WithMessage("Typo de warehouse inválido.");
        }

        private bool IsOfTypeWarehouseType(string type)
        {
            return Enum.GetValues(typeof(WarehouseType))
                .Cast<WarehouseType>().Any(x => x.GetDescription() == type);
        }

    }

}
