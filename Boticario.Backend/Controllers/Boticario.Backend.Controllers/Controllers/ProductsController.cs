using Boticario.Backend.Modules.Products.Dto;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boticario.Backend.Controllers.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductsController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        /// <summary>
        /// Get one Product by its SKU.
        /// </summary>
        /// <param name="sku">SKU of the product</param>
        /// <response code="200">Product returned.</response>
        /// <response code="204">Product not found.</response>
        /// <response code="400">Invalid Parameter.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("{sku}")]
        public async Task<IProductDetails> Get(int sku)
        {
            return await this.productServices.Get(sku);
        }

        /// <summary>
        /// Create a new product and its inventory from specified parameters.
        /// </summary>
        /// <param name="product">Product data</param>
        /// <response code="200">Product created.</response>
        /// <response code="400">Invalid Parameters.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost()]
        public async Task Post([FromBody]ProductOperationDto product)
        {
            await this.productServices.Create(product);
        }

        /// <summary>
        /// Update an existing produc and its inventory from specified parameters.
        /// </summary>
        /// <param name="product">Product data</param>
        /// <response code="200">Product updated.</response>
        /// <response code="400">Invalid Parameters.</response>
        /// <response code="404">Product not found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut()]
        public async Task Put([FromBody]ProductOperationDto product)
        {
            await this.productServices.Update(product);
        }

        /// <summary>
        /// Delete an existing product and its inventory.
        /// </summary>
        /// <param name="sku">SKU of the product</param>
        /// <response code="200">Product deleted.</response>
        /// <response code="400">Invalid Parameters.</response>
        /// <response code="404">Product not found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("{sku}")]
        public async Task Delete(int sku)
        {
            await this.productServices.Delete(sku);
        }
    }
}
