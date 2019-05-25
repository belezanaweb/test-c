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
        public HttpResponseMessage Get()
        {
            try
            {
                List<ProductModel> products = productData.GetProducts();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch(Exception e) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        // GET: api/products/5
        [Route("{sku}")]
        [HttpGet]
        public HttpResponseMessage Get(int sku)
        {
            try
            {
                ProductModel product = productData.GetProductBySKU(sku);

                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception e) {
                return Request.CreateResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        // POST: api/products
        [HttpPost]
        public HttpResponseMessage Post(ProductModel product)
        {
            try
            {
                productData.Add(product);
                return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto {0} adicionado", product.sku));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        // PUT: api/products/5
        [Route("{sku}")]
        [HttpPut]
        public HttpResponseMessage Put(int sku, ProductModel product)
        {
            try
            {
                productData.ModifyProduct(sku, product);
                return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto {0} alterado", sku));
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        // DELETE: api/products/5
        [Route("{sku}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int sku)
        {
            try
            {
                productData.RemoveProduct(sku);

                return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto {0} deletado", sku));
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, e.Message);
            }
        }
    }
}
