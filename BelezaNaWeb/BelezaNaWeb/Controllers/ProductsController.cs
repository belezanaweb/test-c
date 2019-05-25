using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BelezaNaWeb.Data;
using BelezaNaWeb.Models;

namespace BelezaNaWeb.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private ProductsData productData = new ProductsData();
        
        // GET: api/products
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<ProductModel> products = productData.GetProducts();
                return Ok(products);
            }
            catch(Exception e) {
                return BadRequest(e.Message);
            }
        }

        // GET: api/products/5
        [Route("{sku}")]
        [HttpGet]
        public IHttpActionResult Get(int sku)
        {
            try
            {
                ProductModel product = productData.GetProductBySKU(sku);

                return Ok(product);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // POST: api/products
        [HttpPost]
        public IHttpActionResult Post(ProductModel product)
        {
            try
            {
                productData.Add(product);
                return Ok("Ok");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/products/5
        [Route("{sku}")]
        [HttpPut]
        public IHttpActionResult Put(int sku, ProductModel product)
        {
            try
            {
                productData.ModifyProduct(sku, product);
                return Ok("Ok");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/products/5
        [Route("{sku}")]
        [HttpDelete]
        public IHttpActionResult Delete(int sku)
        {
            try
            {
                productData.RemoveProduct(sku);

                return Ok("Ok");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
