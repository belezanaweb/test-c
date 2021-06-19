using System.Collections.Generic;
using System.Threading.Tasks;
using BelezaNaWeb.Api.Data;
using BelezaNaWeb.Api.Data.Repositories.Contract;
using BelezaNaWeb.Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.Api.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productRepository.Index();
            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromBody] Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hasSku = await _productRepository.Show(model.Sku);
            if (hasSku is not null)
                return Conflict(new { message =  "Product sku already registered"});

            try
            {
                var product = new Product();
                product = await _productRepository.Store(model);

                return model;
            }
            catch
            {
                return Problem("Could not create Product");
            }
        }

        
        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> GetBySku(int sku)
        {
            var product = await _productRepository.Show(sku);

            if (product is null)
                return NotFound(value: new { message = "Product not found" });

            return Ok(product);
        }

        [HttpPut]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Put(int sku, [FromBody] Product model, [FromServices] DataContext context)
        {
            if (model.Sku != sku)
                return NotFound(value: new { message = "Product not found" });

            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            try
            {
                var product = await _productRepository.Show(sku);
                                
                product.Sku = model.Sku;
                product.Name = model.Name;
                product.Inventory = model.Inventory;

                await _productRepository.Update(product);

                return Ok(value: model);
            }
            catch
            {
                return BadRequest(error: new { message = "Could not modify product" });
            }
        }

        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<ActionResult<Product>> Delete(int sku)
        {
            var product = await _productRepository.Show(sku);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            try
            {
                await _productRepository.Destroy(product);
                return NoContent();
            }
            catch
            {
                return BadRequest(new { error = "The product could not be removed" });
            }
        }
    }
}
