using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Validators.Products;

namespace Belezanaweb.Application.Products.Commands
{
    public class DeleteProductCommand : RequestBase<Response>
    {
        public DeleteProductCommand(long sku)
        {
            Sku = sku;
        }

        public long Sku { get; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
