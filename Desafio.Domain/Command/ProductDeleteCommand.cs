using Desafio.Domain.Validation;
using FluentValidation.Results;

namespace Desafio.Domain.Command
{
    public class ProductDeleteCommand : ProductCommand
    {
        public ProductDeleteCommand(int sku)
        {
            this.Sku = sku;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
