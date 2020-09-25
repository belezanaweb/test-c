using System;
using MediatR;

namespace BelezaNaWeb.Api.Queries
{
    public sealed class GetProductQuery : IRequest<GetProductResult>
    {
    }

    public sealed class GetProductResult
    {
    }
}
