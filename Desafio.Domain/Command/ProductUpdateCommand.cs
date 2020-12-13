using Desafio.Domain.Validation;
using FluentValidation.Results;

namespace Desafio.Domain.Command
{
    public class ProductUpdateCommand : ProductCommand
    {
        public ProductUpdateCommand(int sku, string name)
        {
            this.Sku = sku;
            this.Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
