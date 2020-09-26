using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Dtos;
using BelezaNaWeb.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BelezaNaWeb.Api.Extensions;
using BelezaNaWeb.Domain.Queries;
using BelezaNaWeb.Domain.Commands;
using Microsoft.Extensions.Logging;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/products")]    
    public sealed class ProductController : GenericController
    {
        #region Constructors

        public ProductController(ILogger<ProductController> logger
            , IMapper mapper
            , IMediator mediator
        )
            : base(logger, mapper, mediator)
        { }

        #endregion

        #region Controller Actions

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new ListProductQuery(1, 10));
            return Ok(result);
        }

        [HttpGet("{sku:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute]int sku)
        {
            var result = await _mediator.Send(new GetProductQuery(sku));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ApiVersion apiVersion, [FromBody] CreateProductRequest model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.ConvertRequestToCommand<CreateProductCommand>(model);
                var result = await _mediator.Send(command);

                return CreatedAtAction(nameof(Get), new { version = apiVersion.ToString(), sku = result.Sku }, result);
            }

            return BadRequest(ModelState.ToErrorResponse());
        }

        [HttpPut("{sku:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit([FromRoute] int sku, [FromBody] EditProductRequest model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.ConvertRequestToCommand<EditProductCommand>(model);
                command.Sku = sku;

                await _mediator.Send(command);

                return NoContent();
            }

            return BadRequest(ModelState.ToErrorResponse());
        }

        [HttpDelete("{sku:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int sku)
        {
            await _mediator.Send(new DeleteProductCommand(sku));
            return NoContent();
        }

        #endregion
    }
}
