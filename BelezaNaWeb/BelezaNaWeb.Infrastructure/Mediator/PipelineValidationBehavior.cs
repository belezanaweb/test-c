using BelezaNaWeb.BuildingBlocks.Notifications;
using FluentValidation;
using MediatR;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infrastructure.Mediator
{
    public class PipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly INotificationContext _notificationContext;
        private readonly IValidator<TRequest> _validator;

        public PipelineValidationBehavior(INotificationContext notificationContext, IValidator<TRequest> validator = null)
        {
            _notificationContext = notificationContext;
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validator is null)
            {
                return next();
            }

            var validationResult = _validator.Validate(request);

            if (validationResult.IsValid)
            {
                return next();
            }

            foreach (var error in validationResult.Errors)
            {
                var property = JsonNamingPolicy.CamelCase.ConvertName(error.PropertyName);
                var validation = error.ErrorCode.Replace("Validator", string.Empty);
                var notification = Notification.CreateValidation(property, validation, error.ErrorMessage);
                _notificationContext.AddNotification(notification);
            }

            return Task.FromResult(default(TResponse));
        }
    }
}
