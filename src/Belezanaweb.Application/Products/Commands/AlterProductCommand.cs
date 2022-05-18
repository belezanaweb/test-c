using Belezanaweb.Application.Validators.Products;

namespace Belezanaweb.Application.Products.Commands
{
    public class AlterProductCommand : BaseProductCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new AlterProductValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
