using BelezaNaWeb.Application.Commands.Products.Create;
using BelezaNaWeb.Application.Commands.Products.Delete;
using BelezaNaWeb.Application.Commands.Products.List;
using BelezaNaWeb.Application.Commands.Products.Update;
using BelezaNaWeb.BuildingBlocks.Attributes;
using BelezaNaWeb.BuildingBlocks.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BelezaNaWeb.WebApi.Controllers.Product
{
    /// <summary>
    /// Products
    /// </summary>
    [Route("products")]
    public class ProductController : ApiControllerBase
    {
        /// <summary>
        /// Get product by Sku
        /// </summary>
        /// <param name="query">Sku</param>
        /// <returns>Product</returns>
        [HttpGet("{sku:long:required}")]
        [Produces200Ok(typeof(SuccessResponse<SearchProductCommandResult>))]
        [Produces404NotFound]
        public async Task<IActionResult> GetAsync([FromRoute] long sku)
        {
            var result = SuccessResponse.Create(await Mediator.Send(new SearchProductCommand().WithSku(sku)));
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="command">product to add</param>
        /// <returns>Product added</returns>
        [HttpPost]
        [Produces200Ok]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="id">product sku</param>
        /// <param name="command">product to update</param>
        /// <returns>NoContent</returns>
        [HttpPatch("{sku:long:required}")]
        [Produces204NoContent]
        [Produces404NotFound]
        public async Task<IActionResult> PutAsync([FromRoute] long sku, [FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command.WithSku(sku));
            return NoContent();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="sku">product sku</param>
        /// <returns>NoContent</returns>
        [HttpDelete("{sku:long:required}")]
        [Produces204NoContent]
        [Produces404NotFound]
        public async Task<IActionResult> DeleteAsync([FromRoute] long sku)
        {
            await Mediator.Send(new DeleteProductCommand().WithSku(sku));
            return NoContent();
        }
    }
}
