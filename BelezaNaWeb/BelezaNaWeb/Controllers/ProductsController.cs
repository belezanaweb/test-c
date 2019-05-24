using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BelezaNaWeb.Models;

namespace BelezaNaWeb.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        List<ProductModel> listProducts = new List<ProductModel>();

        // GET: api/Products/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
