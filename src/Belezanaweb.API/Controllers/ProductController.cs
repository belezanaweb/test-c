using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Application.Products.Queries;
using Belezanaweb.Application.Products.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Belezanaweb.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{sku:long}")]
        public async Task<Response<ProductViewModel>> GetProductBySkuAsync([FromRoute] long sku)
        {
            return await _mediator.Send(new GetProductBySkuQuery(sku));
        }

        [HttpPost]
        public async Task<Response> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<Response> AlterProductAsync([FromBody] AlterProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{sku:long}")]
        public async Task<Response> DeleteProductAsync([FromRoute] long sku)
        {
            return await _mediator.Send(new DeleteProductCommand(sku));
        }
    }
}
