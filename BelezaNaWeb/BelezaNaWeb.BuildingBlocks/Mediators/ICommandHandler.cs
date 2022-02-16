using MediatR;

namespace BelezaNaWeb.BuildingBlocks.Mediators
{
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
          where TRequest : ICommand<TResponse>
    {
    }
}
