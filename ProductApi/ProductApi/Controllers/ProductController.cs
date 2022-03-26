using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{sku}")]
        public ActionResult<Product?> GetProduct(int sku)
        {
            var product = _productRepository.GetProduct(sku);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            try
            {
                _productRepository.CreateProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { sku = product.Sku }, product);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationMessage);
            }
        }

        [HttpPut("{sku}")]
        public IActionResult UpdateProduct(int sku, Product product)
        {
            try
            {
                _productRepository.UpdateProduct(sku, product);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationMessage);
            }
        }

        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(int sku)
        {
            _productRepository.DeleteProduct(sku);

            return NoContent();
        }
    }
}