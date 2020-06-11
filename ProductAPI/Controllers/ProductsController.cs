using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Models;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly ProductDbContext _context;
        //public ProductsController(ProductDbContext context)
        //{
        //    _context = context;
        //}

        /// <summary>
        /// Lista os produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos cadastrados</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return ProductRepository.GetProduct();
            }
            catch (Exception)
            {

                return BadRequest(); ;
            }
        }

        /// <summary>
        /// Obtem o produto pelo seu sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        [HttpGet("{sku}")]
        public ActionResult<Product> Get(int sku)
        {
            return ProductRepository.GetProductBySku(sku);
        }


        /// <summary>
        /// Inclui novo produto
        /// </summary>
        /// <param name="product"> Objeto Produto</param>
        /// <returns>Retorna o objeto Produto incluído</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var prod = ProductRepository.GetProductBySku(Convert.ToInt32(product.Sku));

            if (prod != null)
            {
                throw new InvalidOperationException("Este sku já existe");
            }

            ProductRepository.InsertProduct(product);
            return new CreatedAtRouteResult("", new { sku = product.Sku }, product);
        }

        /// <summary>
        /// Inclui novo produto
        /// </summary>
        /// <param name="sku"> sku do produto a ser alterado</param>
        /// <param name="product"> Objeto Produto</param>
        /// <returns>Retorna o objeto Produto incluído</returns>
        [HttpPut("{sku}")]
        public ActionResult Put(int sku, [FromBody] Product product)
        {
            if (sku != product.Sku)
                {return BadRequest();
            }

            ProductRepository.UpdateProduct(product);
            return Ok();
        }

    }
}
