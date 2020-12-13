using Desafio.Domain.Validation;
using FluentValidation.Results;

namespace Desafio.Domain.Command
{
    public class WarehouseCreateCommand : WarehouseCommand
    {
        public WarehouseCreateCommand(string locality, int quantity, string @type)
        {
            this.Locality = locality;
            this.Quantity = quantity;
            this.Type = @type;
        }

        public override bool IsValid()
        {
            ValidationResult = new WarehouseCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
