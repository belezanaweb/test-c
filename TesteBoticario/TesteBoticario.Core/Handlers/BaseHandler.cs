using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;
using TesteBoticario.Core.Services.Interfaces;

namespace TesteBoticario.Core.Handlers
{
    public abstract class BaseHandler<T> : IRequestHandler<T, BaseResponse> where T : BaseRequest
    {
        protected IMapper _mapper;
        protected IProductService _service;
        public BaseHandler(IMapper mapper, IProductService service) 
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<BaseResponse> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return await SafeExecuteHandler(request, cancellationToken);
            }
            catch (Exception e)
            {
                return new BaseResponse(e.Message, 500);
            }
        }

        public abstract Task<BaseResponse> SafeExecuteHandler(T request, CancellationToken cancellationToken);
    }
}
