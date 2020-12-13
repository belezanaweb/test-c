using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Domain.Command;
using FluentValidation;

namespace Desafio.Domain.Validation
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        public void ValidateSku()
        {
            RuleFor(x => x.Sku)
                .GreaterThan(0).WithMessage("Sku deve ter um valor superior de 0.");
        }
        public void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome deve ser preenchido.");
        }
    }
}
