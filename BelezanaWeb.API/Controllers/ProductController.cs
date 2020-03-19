using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelezanaWeb.Business;
using BelezanaWeb.Business.Interfaces;
using BelezanaWeb.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BelezanaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBusiness productsBusiness;

        public ProductController(IProductBusiness productsBusiness)
        {
            this.productsBusiness = productsBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = this.productsBusiness.Get();

            if (!products.Any())
            {
                return NotFound("Nenhum produto encontrado");
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var productDB = this.productsBusiness.Get(id);

            if (productDB == null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                return Ok(productDB);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var productDB = this.productsBusiness.Insert(product);

            if (productDB == null)
            {
                return BadRequest("Produto já cadastrado");
            }
            else
            {
                return Ok(productDB);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var productDB = this.productsBusiness.Update(id, product);

            if (productDB == null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                return Ok(productDB);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = this.productsBusiness.Delete(id);

            if (product == null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                return Ok();
            }
        }
    }
}
