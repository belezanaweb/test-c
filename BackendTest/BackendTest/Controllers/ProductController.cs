using BackendTest.Domain.Commands.Requests;
using BackendTest.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public Task<CreateProductResponse> Create([FromServices] IMediator mediator, [FromBody] CreateProductRequest command)
        {
            return mediator.Send(command);
        }

        [HttpDelete]
        public Task<DeleteProductResponse> Delete([FromServices] IMediator mediator, [FromQuery] DeleteProductRequest command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<GetProductBySkuResponse> Get([FromServices] IMediator mediator, [FromQuery] GetProductBySkuRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPut]
        public Task<UpdateProductResponse> Put([FromServices] IMediator mediator, [FromBody] UpdateProductRequest command)
        {
            return mediator.Send(command);
        }
    }
}
