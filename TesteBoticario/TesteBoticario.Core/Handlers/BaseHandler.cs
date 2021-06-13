using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;

namespace TesteBoticario.Core.Handlers
{
    public abstract class BaseHandler<T> : IRequestHandler<T, BaseResponse> where T : BaseRequest
    {
        protected IMapper _mapper;
        public BaseHandler(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return await SafeExecuteHandler(request, cancellationToken);
            }
            catch (Exception e)
            {
                return new BaseResponse(e.Message);
            }
        }

        public abstract Task<BaseResponse> SafeExecuteHandler(T request, CancellationToken cancellationToken);
    }
}
