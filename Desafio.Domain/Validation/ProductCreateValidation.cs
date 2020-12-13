using Desafio.Domain.Command;

namespace Desafio.Domain.Validation
{
    public class ProductCreateValidation : ProductValidation<ProductCreateCommand>
    {
        public ProductCreateValidation()
        {
            ValidateName();
        }
                
    }
}
