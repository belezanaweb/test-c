using MediatR;
using AutoMapper;
using BelezaNaWeb.Api.Dtos;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new ListProductQuery(1, 10));
            return Ok(result);
        }

        [HttpGet("{sku:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute]long sku)
        {
            var result = await _mediator.Send(new GetProductQuery(sku));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ApiVersion apiVersion, [FromBody] CreateProductCommand cmd)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(cmd);
                return CreatedAtAction(nameof(Get), new { version = apiVersion.ToString(), sku = result.Sku }, result);
            }

            return BadRequest(ModelState.ToErrorResponse());
        }

        [HttpPut("{sku:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit([FromRoute] long sku, [FromBody] EditProductCommand cmd)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(cmd);
                return NoContent();
            }

            return BadRequest(ModelState.ToErrorResponse());
        }

        [HttpDelete("{sku:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] long sku)
        {
            await _mediator.Send(new DeleteProductCommand(sku));
            return NoContent();
        }

        #endregion
    }
}
