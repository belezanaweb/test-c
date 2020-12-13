using Desafio.Domain.Validation;
using FluentValidation.Results;

namespace Desafio.Domain.Command
{
    public class ProductCreateCommand : ProductCommand
    {
        public ProductCreateCommand(int sku, string name)
        {
            this.Sku = sku;
            this.Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
