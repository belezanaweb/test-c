using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteBoticario.Domain.Application;
using TesteBoticario.Domain.Dto;

namespace TesteBoticario.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _iProductApplication;

        public ProductController(IProductApplication iProductApplication)
        {
            _iProductApplication = iProductApplication;
        }

        /// <summary>
        /// Method that gets the product by your sku code
        /// </summary>
        /// <param name="sku">Sku code</param>
        /// <returns>Selected product</returns>
        [HttpGet("GetProduct")]
        public ActionResult<Product> Get(int sku)
        {
            try
            {
                var result = _iProductApplication.Get(sku);

                if (result != null)
                    return Ok(result);

                return BadRequest($"Nenhum produto encontrado com o sku {sku}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that create a new product in the databse
        /// </summary>
        /// <param name="productModel">The new product</param>
        /// <returns>Message of success or error</returns>
        [HttpPost("AddProduct")]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                _iProductApplication.Add(product);

                return Ok(product);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that delete a product from the database
        /// </summary>
        /// <param name="sku">Sku code of the product that will be deleted</param>
        /// <returns>Message of success or error</returns>
        [HttpDelete("DeleteProduct")]
        public ActionResult Delete(int sku)
        {
            try
            {
                var deleted = _iProductApplication.Delete(sku);

                if (deleted)
                    return Ok("Produto removido com sucesso!");

                return BadRequest($"Nenhum produto encontrado com o sku {sku}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualização do produto
        /// </summary>
        /// <param name="productModel">The product that will be updated</param>
        /// <returns>Message of success or error</returns>
        [HttpPut("UpdateProduct")]
        public ActionResult Update([FromBody] Product product)
        {
            try
            {
                _iProductApplication.Update(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
