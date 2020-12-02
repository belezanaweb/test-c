using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_Boticario.Models;

namespace Teste_Boticario.Controllers
{
    [RoutePrefix("api/v1/Product")]
    public class ProductController : ApiController
    {
        public static List<Product> Products = new List<Product>();

        public Validate Validate = new Validate();

        [HttpGet]
        public List<Product> Get()
        {
            return Products.OrderBy(X => X.Sku).ToList();
        }

        [HttpGet]
        public Product Get(int id)
        {
            return Products.Where(x => x.Sku == id).FirstOrDefault();
        }

        [HttpPost]
        public IHttpActionResult Post(Product p)
        {
            if (!String.IsNullOrEmpty(Validate.Product(p, p.Sku, Products)))
            {
                return BadRequest(Validate.message);
            }

            Products.Add(p);
            return Content(HttpStatusCode.Created, "Produto criado com sucesso");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Product p)
        {
            Product produto = Products.Where(x => x.Sku == id).FirstOrDefault();

            if (!String.IsNullOrEmpty(Validate.Product(p, id)))
            {
                return BadRequest(Validate.message);
            }

            if (produto != null)
            {
                Products.Remove(produto);
                Products.Add(p);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Product p = Products.Where(x => x.Sku == id).FirstOrDefault();

            if (p != null)
            {
                Products.Remove(p);
                return Ok();
            }

            return NotFound();
        }
    }
}
