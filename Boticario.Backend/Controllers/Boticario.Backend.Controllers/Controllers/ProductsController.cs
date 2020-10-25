using Boticario.Backend.Controllers.Dto.Inputs;
using Boticario.Backend.Modules.Products.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Controllers.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Get one Product by its SKU.
        /// </summary>
        /// <param name="sku">SKU of the product</param>
        /// <response code="200">Product returned.</response>
        /// <response code="204">Product not found.</response>
        /// <response code="400">Invalid Parameter.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("{sku}")]
        public Task<IProductDetails> Get(int sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new product and its inventory from specified parameters.
        /// </summary>
        /// <param name="product">Product data</param>
        /// <response code="200">Product created.</response>
        /// <response code="400">Invalid Parameters.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost()]
        public Task Post([FromBody]ProductInputDto product)
        {
            throw new NotImplementedException();
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
        public Task Put([FromBody]ProductInputDto product)
        {
            throw new NotImplementedException();
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
        public Task Delete(int sku)
        {
            throw new NotImplementedException();
        }
    }
}
