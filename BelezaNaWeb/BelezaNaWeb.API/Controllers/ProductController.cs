using System;
using System.Collections.Generic;
using BelezaNaWeb.API.Model;
using BelezaNaWeb.Business;
using BelezaNaWeb.CrossCutting;
using BelezaNaWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBusiness Bus { get; set; } = new ProductBusiness();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var products = Bus.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponse(ex.Message));
            }
        }

        // GET api/values/5
        [HttpGet("{sku}")]
        public ActionResult<Product> Get(int sku)
        {
            try
            {
                var product = Bus.GetById(sku);
                return Ok(product);
            }
            catch (NotFoundException nfex)
            {
                return NotFound(new ResultResponse("424", nfex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponse(ex.Message));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            try
            {
                Bus.Add(product);
                return Ok();
            }
            catch (AlreadyExistsException aeex)
            {
                return UnprocessableEntity(new ResultResponse("422",aeex.Message));
            }            
            catch (Exception ex)
            {
                return BadRequest(new ResultResponse(ex.Message));
            }
        }

        [HttpPut("{sku}")]
        public ActionResult Put(int sku, [FromBody]Product product)
        {
            product.Sku = sku;
            try
            {
                Bus.Update(product);
                return Ok();
            }
            catch (NotFoundException nfex)
            {
                return NotFound(new ResultResponse("424", nfex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponse(ex.Message));
            }

            
        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(int sku)
        {
            try
            {
                Bus.Delete(sku);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponse(ex.Message));
            }
        }
    }
}
