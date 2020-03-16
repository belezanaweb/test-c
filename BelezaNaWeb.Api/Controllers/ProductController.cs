using System.Net.Mime;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Commands.CreateProductCommand.Input;
using BelezaNaWeb.Domain.Commands.RemoveProductCommand.Input;
using BelezaNaWeb.Domain.Commands.UpdateProductCommand.Input;
using BelezaNaWeb.Domain.Handlers;
using BelezaNaWeb.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.Api.Controllers {
    [Route("v1/products")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IProductRepository repository;
        private readonly ProductHandler handler;

        public ProductController(IProductRepository repository, ProductHandler handler) {
            this.repository = repository;
            this.handler = handler;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getAll() {
            return Ok(this.repository.getAll());
        }

        [HttpGet]
        [Route("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getBySku([FromRoute]int sku) {
            var product = this.repository.getProduct(sku);
            return product != null ? Ok(product): (IActionResult)NotFound(product);
        }

        [HttpPost]
        [Route("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult post([FromBody]CreateProductCommand command) {
            var result = (CommandResult)this.handler.handle(command);
            return result.success ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut]
        [Route("{sku}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult put([FromBody]UpdateProductCommand command, [FromRoute]int sku) {
            //Forçando a SKU informada na Rota
            command.sku = sku; 
            var result = (CommandResult)this.handler.handle(command);
            return result.success ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete]
        [Route("{sku}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult delete([FromRoute]int sku) {
            var command = new RemoveProductCommand { sku = sku };
            var result = (CommandResult)this.handler.handle(command);
            return result.success ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
