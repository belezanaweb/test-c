using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Belezanaweb.Application.Core.Commands
{
    public abstract class RequestBase<TQuery> : IRequestBase, IRequest<TQuery>
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
