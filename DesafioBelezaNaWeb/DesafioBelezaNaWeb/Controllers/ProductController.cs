using DesafioBelezaNaWeb.Models;
using DesafioBelezaNaWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBelezaNaWeb.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{sku}")]
        public IActionResult GetProduct(int sku)
        {
            var (exists, product) = _productRepository.GetProduct(sku);
            if (!exists)
                return NotFound("Produto não encontrado!");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var errors = ModelState.Select(x => x.Value.Errors.First().ErrorMessage).FirstOrDefault();

                    return BadRequest(errors);
                }

                var produtos = _productRepository.CreateProduct(product);

                return Ok($"Produto {product.Sku} - {product.Name} criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Select(x => x.Value.Errors.First().ErrorMessage).FirstOrDefault();

                    return BadRequest(errors);
                }

                _productRepository.EditProduct(product);

                return Ok($"Produto editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(long sku)
        {
            try
            {
                _productRepository.DeleteProduct(sku);

                return Ok("Produto deletado com sucesso.");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
