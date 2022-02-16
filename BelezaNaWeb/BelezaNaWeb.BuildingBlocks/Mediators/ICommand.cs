using MediatR;

namespace BelezaNaWeb.BuildingBlocks.Mediators
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
