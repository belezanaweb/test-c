using FluentValidation.Results;

namespace Projeto.Domain.Services
{
    public abstract class BaseService
    {
        public ValidationResult ValidationResult { get; set; }

        protected bool IsValid(ValidationResult validationResult) 
        {
            ValidationResult = validationResult;
            return validationResult.IsValid;
        }
    }
}
