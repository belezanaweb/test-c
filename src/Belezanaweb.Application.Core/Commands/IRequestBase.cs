using FluentValidation.Results;

namespace Belezanaweb.Application.Core.Commands
{
    public interface IRequestBase
    {
        ValidationResult ValidationResult { get; }
    }
}
