
using Boticario.Domain.Models;
using FluentValidation;

namespace Boticario.Domain.Validations
{
    public class ProductsSaveValidator : AbstractValidator<Products>
    {
        public ProductsSaveValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200).MinimumLength(3).WithMessage("O nome do produto deve ter de 3 a 200 caracteres");
            RuleFor(x => x.Sku).GreaterThan(0).WithMessage("O sku tem que ser maior que 0");

        }


    }

   



    public class ProductsUpdateValidator : AbstractValidator<Products>
    {
        public ProductsUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200).MinimumLength(3).WithMessage("O nome do produto deve ter de 3 a 200 caracteres");
            
        }
    }

}
