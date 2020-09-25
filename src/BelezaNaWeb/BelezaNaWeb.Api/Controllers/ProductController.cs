using AutoMapper;
using BelezaNaWeb.Api.Contracts.Responses;
using BelezaNaWeb.Api.Extensions;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Framework.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {

            var collection = await _repository.GetAll(
                include: x => x
                    .Include(p => p.Warehouses)
            );

            return Ok(collection);
        }

        [HttpGet("{sku:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute]long sku)
        {
            var result = await _repository.Get(sku);
            if (result == null)
                return NotFound(ErrorResponse.DefaultNotFoundResponse());

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] long sku)
        {
            await _mediator.Send(new DeleteProductCommand(sku));
            return NoContent();
        }

        #endregion
    }
}
