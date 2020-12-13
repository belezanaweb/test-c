using Desafio.Domain.Command;
using FluentValidation;

namespace Desafio.Domain.Validation
{
    public abstract class WarehouseValidation<T> : AbstractValidator<T> where T : WarehouseCommand
    {
        public void ValidateLocality()
        {
            RuleFor(x => x.Locality)
                .NotEmpty().WithMessage("Localidade deve ser preenchido.");
        }

        public void ValidateType()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Tipo deve ser preenchido.");
        }
    }
}
