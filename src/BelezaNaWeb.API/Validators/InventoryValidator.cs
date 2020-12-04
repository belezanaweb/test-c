using BelezaNaWeb.API.Dtos.Inventory;
using BelezaNaWeb.API.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Validators
{
    public class InventoryValidator : AbstractValidator<CreateInventoryDto>
    {
        public InventoryValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.WareHouses).NotNull().NotEmpty();
            RuleForEach(x => x.WareHouses).NotNull().NotEmpty().SetValidator(new WareHouseValidator());
        }
    }
}
