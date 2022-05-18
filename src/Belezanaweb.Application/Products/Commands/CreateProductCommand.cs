using Belezanaweb.Application.Validators.Products;

namespace Belezanaweb.Application.Products.Commands
{
    public class CreateProductCommand : BaseProductCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new CreateProductValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
