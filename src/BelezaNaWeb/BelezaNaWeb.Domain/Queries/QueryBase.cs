using MediatR;

namespace BelezaNaWeb.Domain.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult>
        where TResult : class
    { }
}
