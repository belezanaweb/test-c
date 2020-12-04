using BelezaNaWeb.API.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Inventory).NotNull().NotEmpty().SetValidator(new InventoryValidator());
        }
    }
}
