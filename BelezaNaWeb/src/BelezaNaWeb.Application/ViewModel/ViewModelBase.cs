using DomainValidationCore.Validation;

namespace BelezaNaWeb.Application.ViewModel
{
    public abstract class ViewModelBase
    {
        protected ViewModelBase()
        {
            Validacao = new ValidationResult();
        }

        public ValidationResult Validacao { get; set; }
    }
}
