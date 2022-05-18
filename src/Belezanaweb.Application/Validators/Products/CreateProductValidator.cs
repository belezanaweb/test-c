using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Domain.Products.Repositories;
using FluentValidation;

namespace Belezanaweb.Application.Validators.Products
{
    public class CreateProductValidator : BaseProductValidator
    {
        public CreateProductValidator() : base()
        {
        }
    }
}
