using Boticario.Domain.Handlers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Boticario.ApplicationService.Services
{
    public class ApplicationServiceBase<TEntity> where TEntity: class
    {
        protected ValidationResult _validationResults { get; set; }
        protected INotification _notifications { get;  }
        public ILogger _logger { get; private set; }

        public ApplicationServiceBase(ILogger logger,  INotification notifications)
        {
            _logger = logger;
            _notifications = notifications;

        }


        public bool ModelIsValid(TEntity entity, AbstractValidator<TEntity> validator)
        {
            _validationResults = validator.Validate(entity);

            //Joga os erros de models para o validation
            var erros = _validationResults?.Errors?.Select(x => x.ErrorMessage).ToList();
            if(erros!=null && erros.Count > 0)
                _notifications.AddErrors(erros);
            

            return _validationResults.IsValid;
        }

        public string ReturnValidationsToString()
        {
            var erros = _notifications?.GetErrors()?.Select(x => x.Message).ToList();

            return erros != null ? string.Join(',', erros) : "";
        }

    }

}
