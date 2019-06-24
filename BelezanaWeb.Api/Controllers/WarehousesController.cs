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
    public class WarehouseController : BaseController
    {
        private readonly IWarehouseService warehouseService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="service">Context (Ioc).</param>
        public WarehouseController(IWarehouseService warehousesService)
        {
            this.warehouseService = warehousesService;
        }

        /// <summary>
        /// Gets the document by the ID.
        /// </summary>
        /// <param name="id">Document key.</param>
        /// <returns></returns>
        [SwaggerOperation(Tags = new[] { "Warehouse" })]
        [SwaggerResponse(HttpStatusCode.NoContent, "Nenhum conteúdo encontrado.")]
        [SwaggerResponse(HttpStatusCode.OK, "Operação realizada com sucesso.", typeof(List<WarehouseMessage>))]
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(long id)
        {
            var response = warehouseService.GetById(id);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            var message = WarehouseConvert.ToMessage(response.Object);
            return await ResponseOk(message);
        }

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns>Documents</returns>
        [SwaggerOperation(Tags = new[] { "Warehouses" })]
        [SwaggerResponse(HttpStatusCode.NoContent, "Nenhum conteúdo encontrado.")]
        [SwaggerResponse(HttpStatusCode.OK, "Operação realizada com sucesso.", typeof(List<WarehouseMessage>))]
        [HttpGet]
        public async Task<ObjectResult> GetAll()
        {
            var response = warehouseService.GetAll();
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            var messages = WarehouseConvert.ToMessage(response.Objects);
            return await ResponseOk(messages);
        }

        /// <summary>
        /// Add a new document.
        /// </summary>
        /// <param name="message">Model to add.</param>
        [SwaggerOperation(Tags = new[] { "Warehouse" })]
        [SwaggerResponse(422, "Requisição não processável.")]
        [SwaggerResponse(HttpStatusCode.Created, "Operação realizada com sucesso.", typeof(WarehouseMessage))]
        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]WarehouseMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = WarehouseConvert.ToModel(message);

            var response = warehouseService.Save(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseCreated("Inserted successfully!");
        }

        /// <summary>
        /// Update a document.
        /// </summary>
        /// <param name="message">Model to update.</param>
        [SwaggerOperation(Tags = new[] { "Warehouses" })]
        [SwaggerResponse(422, "Requisição não processável.")]
        [SwaggerResponse(HttpStatusCode.NoContent, "Operação realizada com sucesso.")]
        [HttpPut]
        public async Task<ObjectResult> Put([FromBody]WarehouseMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = WarehouseConvert.ToModel(message);

            var response = warehouseService.Save(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseNoContent();
        }

    }
}
