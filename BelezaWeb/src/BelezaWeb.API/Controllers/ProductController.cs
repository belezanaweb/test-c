using BelezaWeb.Domain.Command.Input.AddProduct;
using BelezaWeb.Domain.Command.Input.Product;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BelezaWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator, IRepository<Product> repository)
        {
            _mediator = mediator;
        }
              

        [HttpGet("{sku}")]
        public async Task<IActionResult> Get(int sku)
        {
            var command = new GetProductCommand
            {
                sku = sku
            };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{sku}")]
        public async Task<IActionResult> Delete(int sku)
        {
            var obj = new DeleteProductCommand { Sku = sku };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }

    }
}
