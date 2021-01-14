
using DomainValidationCore.Validation;

namespace BelezaNaWeb.Domain.Entities
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            Validacao = new ValidationResult();
        }

        public ValidationResult Validacao { get; set; }
    }
}
