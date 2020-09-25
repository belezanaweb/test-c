using System;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BelezaNaWeb.Api.Extensions;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Api.Contracts.Requests;
using BelezaNaWeb.Api.Contracts.Responses;
using BelezaNaWeb.Framework.Data.Repositories;
using BelezaNaWeb.Api.Commands;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/products")]    
    public sealed class ProductController : GenericController
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _repository;

        #endregion

        #region Constructors

        public ProductController(ILogger<ProductController> logger, IMapper mapper
            , IMediator mediator
            , IProductRepository repository
        )
            : base(logger, mapper, mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

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

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Create(ApiVersion apiVersion, [FromBody] CreateProductRequest model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = Mapper.ConvertRequestToEntity<Product>(model);

        //        await _repository.Create(entity);
        //        await _repository.CompleteAsync();

        //        return CreatedAtAction(nameof(Get), new { version = apiVersion.ToString(), sku = entity.Sku }, entity);
        //    }

        //    return BadRequest(ModelState.ToErrorResponse());
        //}

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
        public async Task<IActionResult> Edit([FromRoute] long sku, [FromBody] EditProductRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.Get(sku);
                if (result == null)
                    return NotFound(ErrorResponse.DefaultNotFoundResponse());

                var entity = Mapper.ConvertRequestToEntity<Product>(model);
                entity.Sku = sku;

                await _repository.Update(sku, entity);
                await _repository.CompleteAsync();

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
            var entity = await _repository.Get(sku);
            if (entity == null)
                return NotFound(ErrorResponse.DefaultNotFoundResponse());

            _repository.Delete(entity);
            _repository.Complete();

            return NoContent();
        }

        #endregion
    }
}
