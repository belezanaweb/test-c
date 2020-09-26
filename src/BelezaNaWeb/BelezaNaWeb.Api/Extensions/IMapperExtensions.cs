using MediatR;
using AutoMapper;
using BelezaNaWeb.Domain.Commands;

namespace BelezaNaWeb.Api.Extensions
{
    public static class IMapperExtensions
    {
        #region Extension Methods - ConvertRequestToCommand

        public static TCommand ConvertRequestToCommand<TCommand, TRequest>(this IMapper mapper, TRequest request)
            where TCommand : class, ICommand
            where TRequest : class, IBaseRequest
        {
            return mapper.Map<TRequest, TCommand>(request);
        }

        public static TCommand ConvertRequestToCommand<TCommand>(this IMapper mapper, IBaseRequest request)
            where TCommand : class, ICommand
        {
            return (TCommand)mapper.Map(request, request.GetType(), typeof(TCommand));
        }

        #endregion       
    }
}
