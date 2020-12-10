using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteGuilhermeHelaehil.Models;
using TesteGuilhermeHelaehil.Services;

namespace TesteGuilhermeHelaehil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private ProductService productService;

        public ProductController()
        {
            productService = new ProductService();
        }

        // GET: api/product
        // Recupera todos os produtos
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        // GET api/product/{sku}
        // Recuperação de produto por SKU
        [HttpGet("{sku}")]
        public IActionResult FindProduct(int sku)
        {
            var result = productService.FindProduct(sku);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("SKU não encontrada!");
            }
        }

        // POST api/product
        // Criação de produto 
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var ProductExists = productService.FindProduct(product.sku);
            if(ProductExists == null)
            {
                var result = productService.CreateProduct(product);
                return Ok(result);
            }
            return Problem("SKU já cadastrada no sistema!");
        }

        // PUT api/product/{sku}
        // Edição de produto por SKU
        [HttpPut("{sku}")]
        public IActionResult UpdateProduct(int sku, Product product)
        {
            var ProductExists = productService.FindProduct(product.sku);
            if (ProductExists != null)
            {
                var result = productService.UpdateProduct(sku, product);
                return Ok(result);
            }
            return NotFound("SKU não encontrada!");
        }

        // DELETE api/product/{sku}
        // Deleção de produto por SKU
        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(int sku)
        {
            var ProductExists = productService.FindProduct(sku);
            if (ProductExists != null)
            {
                var result = productService.DeleteProduct(sku);
                if (result > 0)
                {
                    return Ok("Produto deletado com sucesso!");
                }
                else
                {
                    Problem("Falha ao deletar produto!");
                }
            }
            return NotFound("SKU não encontrada!");
        }
    }
}
