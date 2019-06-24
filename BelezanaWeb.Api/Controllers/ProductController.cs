using BelezanaWeb.Interface.Service;
using BelezanaWeb.Model.Facade;
using BelezanaWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BelezanaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [SwaggerResponse(HttpStatusCode.Unauthorized, "Requisição requer autenticação.")]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Sem conteúdo.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição mal formada.")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Recurso não encontrado.")]
    [SwaggerResponse(422, "Requisição não processável.")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro Interno.")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="service">Context (Ioc).</param>
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Document key.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(HttpStatusCode.NoContent, "Nenhum conteúdo encontrado.")]
        [SwaggerResponse(HttpStatusCode.OK, "Operação realizada com sucesso.", typeof(List<ProductMessage>))]
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(long id)
        {
            var response = productService.GetById(id);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            var message = ProductConvert.ToMessage(response.Object);
            return await ResponseOk(message);
        }

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Documents</returns>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(HttpStatusCode.NoContent, "Nenhum conteúdo encontrado.")]
        [SwaggerResponse(HttpStatusCode.OK, "Operação realizada com sucesso.", typeof(List<ProductMessage>))]
        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var response = productService.GetAll();
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            var messages = ProductConvert.ToMessage(response.Objects);
            return await ResponseOk(messages);
        }

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Documents</returns>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(HttpStatusCode.NoContent, "Nenhum conteúdo encontrado.")]
        [SwaggerResponse(HttpStatusCode.OK, "Operação realizada com sucesso.", typeof(List<ProductMessage>))]
        [HttpGet]
        [Route("withwarehouses")]
        public async Task<ObjectResult> GetWithWarehouses()
        {
            var response = productService.GetWithWarehouses();
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            var messages = ProductConvert.ToMessage(response.Objects);
            return await ResponseOk(messages);
        }

        /// <summary>
        /// Add a new document.
        /// </summary>
        /// <param name="message">Model to add.</param>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(422, "Requisição não processável.")]
        [SwaggerResponse(HttpStatusCode.Created, "Operação realizada com sucesso.", typeof(ProductMessage))]
        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]ProductMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = ProductConvert.ToModel(message);

            var response = productService.Save(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseCreated("Inserted successfully!");
        }

        /// <summary>
        /// Update a document.
        /// </summary>
        /// <param name="message">Model to update.</param>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(422, "Requisição não processável.")]
        [SwaggerResponse(HttpStatusCode.NoContent, "Operação realizada com sucesso.")]
        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]ProductMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = ProductConvert.ToModel(message);

            var response = productService.Update(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseNoContent();
        }

        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <param name="message">Model to update.</param>
        [SwaggerOperation(Tags = new[] { "Product" })]
        [SwaggerResponse(422, "Requisição não processável.")]
        [SwaggerResponse(HttpStatusCode.NoContent, "Operação realizada com sucesso.")]
        [HttpDelete]
        public async Task<ObjectResult> Delete([FromBody]ProductMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = ProductConvert.ToModel(message);

            var response = productService.Delete(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseNoContent();
        }

    }
}
