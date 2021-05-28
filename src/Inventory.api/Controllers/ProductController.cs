using Inventory.Core.Notification;
using Inventory.Domain.Events;
using Inventory.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        public ProductController(INotifiable<DomainErrorRaised> notifieble)
        {
            notifieble.Handle += this.Handle;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Core.Product>> Get([FromServices] ProductQuery products)
        {
            var product = products.GetAll().ToList();
            return product;
        }

        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<Core.Product>> Get([FromServices] ProductQuery products, int sku)
        {
            var product = await products.GetAsync(sku);
            if (product == null)
                return NotFound(sku);
            return product;
        }

        [HttpPut]
        [Route("{sku:int}")]
        public async Task<ActionResult<Core.Product>> Put([FromServices] NetHacksPack.Core.Extensions.Events.IMediatorHandler mediatorHandler, [FromBody] Domain.Commands.UpdateProductCommand command, int sku)
        {
            var result = await mediatorHandler.SendCommand(command);
            if (ModelState.ContainsKey("sku:notfound"))
                return NotFound($"The sku {command.Sku} was not found");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return (Core.Product)command;
        }

        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<ActionResult<Core.Product>> Delete([FromServices] NetHacksPack.Core.Extensions.Events.IMediatorHandler mediatorHandler, int sku)
        {
            var command = new Domain.Commands.RemoveProductCommand(sku);
            var result = await mediatorHandler.SendCommand(command);
            if (ModelState.ContainsKey("sku:notfound"))
                return NotFound($"The sku {command.Sku} was not found");
            return Ok(command.Product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Commands.CreateProductCommand command, [FromServices] NetHacksPack.Core.Extensions.Events.IMediatorHandler mediatorHandler)
        {
            var result = await mediatorHandler.SendCommand(command);
            if (ModelState.ContainsKey("sku:duplicated"))
                return StatusCode((int)HttpStatusCode.Conflict, $"The sku {command.Sku} has been already registered before");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (result)
                return Ok((int)HttpStatusCode.Created);
            return BadRequest();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Task Handle(DomainErrorRaised notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                foreach (var item in notification.Errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            });
        }
    }
}
