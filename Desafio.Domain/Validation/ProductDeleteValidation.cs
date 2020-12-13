using Desafio.Domain.Command;

namespace Desafio.Domain.Validation
{
    public class ProductDeleteValidation : ProductValidation<ProductDeleteCommand>
    {
        public ProductDeleteValidation()
        {
            ValidateSku();
        }
    }
}
