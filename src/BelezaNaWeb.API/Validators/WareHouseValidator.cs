using BelezaNaWeb.API.Dtos.WareHouse;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Validators
{
    public class WareHouseValidator : AbstractValidator<WareHouseDto>
    {
        public WareHouseValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x.Locality).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.Type).NotNull().NotEmpty();
        }
    }
}
