using Desafio.Domain.Command;

namespace Desafio.Domain.Validation
{
    public class ProductUpdateValidation : ProductValidation<ProductUpdateCommand>
    {
        public ProductUpdateValidation()
        {
            ValidateSku();
            ValidateName();
        }
    }
}
