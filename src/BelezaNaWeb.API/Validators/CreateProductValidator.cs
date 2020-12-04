using BelezaNaWeb.API.Dtos.Product;
using FluentValidation;

namespace BelezaNaWeb.API.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.Sku).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Inventory).NotNull().NotEmpty().SetValidator(new InventoryValidator());
        }
    }
}
