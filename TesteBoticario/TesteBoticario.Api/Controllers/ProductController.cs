using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;

namespace TesteBoticario.Api.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<BaseResponse>> CreateProduct(CreateProductRequest request)
        {
            return await _mediator.Send(request);                
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<BaseResponse>> GetProduct(GetProductRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<BaseResponse>> UpdateProduct(UpdateProductRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<BaseResponse>> DeleteProduct(DeleteProductRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
