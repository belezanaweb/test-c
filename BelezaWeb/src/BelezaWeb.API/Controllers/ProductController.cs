using MediatR;
using BelezaWeb.Domain.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Requests;

namespace BelezaWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator Mediator;

        public ProductController(IMediator mediator, IRepository<Product> repository)
        {
            Mediator = mediator;
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> Get(int sku)
        {
            var request = new GetProductRequest { Sku = sku };
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductRequest request)
        {
            var response = await Mediator.Send(request);

            if (response.HasError)
                return BadRequest(response.Data);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductRequest request)
        {
            var response = await Mediator.Send(request);

            if (response.HasError)
                return BadRequest(response.Data);

            return Ok(response);
        }

        [HttpDelete("{sku}")]
        public async Task<IActionResult> Delete(int sku)
        {
            var item = new DeleteProductRequest { Sku = sku };
            var res = await Mediator.Send(item);

            return Ok(res);
        }
    }
}
