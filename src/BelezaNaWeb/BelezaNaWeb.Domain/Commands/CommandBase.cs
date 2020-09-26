using MediatR;

namespace BelezaNaWeb.Domain.Commands
{
    public interface ICommand
    { }

    public abstract class CommandBase<TResult> : IRequest<TResult>, ICommand        
    { }
}
