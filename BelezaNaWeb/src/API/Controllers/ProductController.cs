using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Interfaces.Services;
using Model.Models;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        /// <summary>
        /// Get a product by Sku.
        /// </summary>
        /// <param name="id">Sku Code</param>
        /// <returns><see cref="Product"/> object</returns>
        public Product Get(int id) => _productService.Get(id);

        /// <summary>
        /// Adds a <see cref="Product"/>.
        /// </summary>
        /// <param name="product"><see cref="Product"/> object</param>
        /// <returns>
        /// A <see cref="HttpResponseMessage"/> object with <see cref="HttpStatusCode"/> 201
        /// otherwise 400 error code.
        /// </returns>
        [HttpPost]
        public HttpResponseMessage Add([FromBody]Product product)
        {
            try
            {
                _productService.Add(product);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Updates a <see cref="Product"/>.
        /// </summary>
        /// <param name="product"><see cref="Product"/> object</param>
        /// <returns>
        /// A <see cref="HttpResponseMessage"/> object with <see cref="HttpStatusCode"/> 201
        /// otherwise 400 error code.
        /// </returns>
        [HttpPut]
        public HttpResponseMessage Update([FromBody]Product product)
        {
            try
            {
                _productService.Update(product);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
