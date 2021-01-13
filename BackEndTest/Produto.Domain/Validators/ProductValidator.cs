using FluentValidation;
using Produto.Domain.Models;

namespace Produto.Domain.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Nome do produto precisa ser preenchido");

            RuleFor(a => a.Sku)
                .NotEmpty()
                .WithMessage("Sku do produto precisa ser informado");
        }
    }
}
