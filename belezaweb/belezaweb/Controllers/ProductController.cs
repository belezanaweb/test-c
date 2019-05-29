using belezaweb.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace belezaweb.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>();

        [HttpPost]
        [Route("createProduct")]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
                return NotFound($"Produto com sku = {product.Id} já cadastrado");
            _products.Add(product);

            return Ok($"Produto cadastrado com sucesso!"); ;
        }

        [HttpPut]
        [Route("AlterProduct/{sku}")]
        public IActionResult AlterProduct([FromRoute]int sku, [FromBody]Product product)
        {
            var aux = _products.FirstOrDefault(n => n.Id == sku);
            if (aux == null)
                return NotFound($"Produto {sku} não encontrado.");

            _products.Remove(aux);
            _products.Add(product);

            return Ok($"Produto alterado com sucesso!");
        }

        [HttpDelete]
        [Route("delete/{sku}")]
        public IActionResult Delete([FromRoute]int sku)
        {
            var aux = _products.FirstOrDefault(n => n.Id == sku);

            if (aux == null)
                return NoContent();

            _products.Remove(aux);

            return Ok($"Produto {sku} excluído com sucesso!");
        }

        [HttpGet]
        [Route("getproduct/{sku}")]
        public IActionResult GetProduct([FromRoute]int sku)
        {
            var result = _products.FirstOrDefault(n => n.Id == sku);

            if (result == null)
                return NotFound($"Produto {sku} não encontrado");

            return Ok(result);
        }
    }
}