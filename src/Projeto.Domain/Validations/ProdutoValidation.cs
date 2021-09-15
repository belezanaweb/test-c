using FluentValidation;
using Projeto.Domain.Models;
using Projeto.Domain.Resources;

namespace Projeto.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            ValidateSku();
            ValidateNome();
        }

        protected void ValidateSku()
        {
            RuleFor(c => c.Sku)
                .GreaterThan(0)
                    .WithMessage(ProdutoResource.SkuRequired);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage(ProdutoResource.NomeRequired)
                .MaximumLength(255)
                    .WithMessage(ProdutoResource.NomeMaximumLength);
        }
    }
}
