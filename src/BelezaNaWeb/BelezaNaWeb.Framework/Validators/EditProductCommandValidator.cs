using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using BelezaNaWeb.Domain.Commands;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Framework.Validators
{
    internal sealed class EditProductCommandValidator : GenericValidator<EditProductCommand>
    {
        #region Constructors

        public EditProductCommandValidator(ILogger<EditProductCommandValidator> logger)
            : base(logger)
        { }

        #endregion

        #region Overriden Methods

        public override void Configure()
        {
            RuleFor(p => p.Sku)
                .GreaterThan(0)
                    .WithMessage("Sku code must be greater than zero.")
                    .WithState(p => new ValidationFailure(nameof(p.Sku), "Sku code must be greater than zero."))
                .LessThanOrEqualTo(int.MaxValue)
                    .WithMessage($"Sku code must be less than or equal to {int.MaxValue}.")
                    .WithState(p => new ValidationFailure(nameof(p.Sku), $"Sku code must be less than or equal to {int.MaxValue}."));

            RuleFor(p => p.Name)
                .NotNull()
                    .WithMessage("Name is required.")
                    .WithState(p => new ValidationFailure(nameof(p.Name), "Name is required."))
                .NotEmpty()
                    .WithMessage("Name is required.")
                    .WithState(p => new ValidationFailure(nameof(p.Name), "Name is required."));

            RuleFor(p => p.Warehouses)
                .Must(BeUniqueWarehouses)
                    .WithMessage("The warehouse must be unique.")
                    .WithState(p => new ValidationFailure(nameof(p.Warehouses), "The warehouse must be unique."));
        }

        #endregion

        #region Private Methods

        public bool BeUniqueWarehouses(IEnumerable<EditProductWarehouseCommand> warehouses)
            => !warehouses.GroupBy(x => new { x.Locality, x.Type })
                .Select(x => new { x.Key, Count = x.Count() })
                .Any(x => x.Count > 1);

        #endregion
    }
}
