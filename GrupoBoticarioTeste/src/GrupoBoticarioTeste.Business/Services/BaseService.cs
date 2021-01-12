using FluentValidation;
using FluentValidation.Results;
using GrupoBoticarioTeste.Business.Interfaces.Services;
using GrupoBoticarioTeste.Business.Notificacoes;

namespace GrupoBoticarioTeste.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificadorService _notificador;

        protected BaseService(INotificadorService notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
