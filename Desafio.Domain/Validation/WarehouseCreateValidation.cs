using Desafio.Domain.Command;

namespace Desafio.Domain.Validation
{
    public class WarehouseCreateValidation : WarehouseValidation<WarehouseCreateCommand>
    {
        public WarehouseCreateValidation()
        {
            ValidateLocality();
            ValidateType();
        }
    }
}
