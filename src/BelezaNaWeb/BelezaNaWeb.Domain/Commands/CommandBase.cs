using MediatR;

namespace BelezaNaWeb.Domain.Commands
{
    public abstract class CommandBase<TResult> : IRequest<TResult>        
    { }
}
