using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;

namespace TesteBoticario.Api.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates new product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Create
        ///     {
        ///         "sku": 43264,
        ///         "name": "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
        ///         "inventory": {
        ///            "warehouses": [
        ///                {
        ///                     "locality": "SP",
        ///                    "quantity": 12,
        ///                    "type": "ECOMMERCE"
        ///                 },
        ///                 {
        ///                    "locality": "MOEMA",
        ///                    "quantity": 3,
        ///                     "type": "PHYSICAL_STORE"
        ///                 }
        ///                 ]
        ///             }
        ///         }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Sku, name and time of creation of created product</returns>
        /// <response code="200">Returns the created product</response>
        /// <response code="400">Product did not succeded validation or some error occured</response> 
        /// <response code="409">Product could not be created because another one with the same sku identifier already exists</response>
        /// <response code="500">An internal server error has occured</response>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<BaseResponse>> CreateProduct(CreateProductRequest request)
        {
            return await _mediator.Send(request);                
        }

        /// <summary>
        /// Retrieves product by sku.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Get
        ///     {
        ///         "sku": 43264
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Product with inventory and warehouses</returns>
        /// <response code="200">Returns corresponding product</response>
        /// <response code="404">Product with this sku identifier could not be found</response>
        /// <response code="500">An internal server error has occured</response>
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<BaseResponse>> GetProduct(GetProductRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Update
        ///     {
        ///         "sku": 43264,
        ///         "name": "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
        ///         "inventory": {
        ///            "warehouses": [
        ///                {
        ///                     "locality": "SP",
        ///                    "quantity": 12,
        ///                    "type": "ECOMMERCE"
        ///                 },
        ///                 {
        ///                    "locality": "MOEMA",
        ///                    "quantity": 3,
        ///                     "type": "PHYSICAL_STORE"
        ///                 }
        ///                 ]
        ///             }
        ///         }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Sku, name and time of update of updated product</returns>
        /// <response code="200">Returns the updated product</response>
        /// <response code="400">Product did not succeded validation or some error occured</response> 
        /// <response code="404">Product with this sku identifier could not be found</response>
        /// <response code="500">An internal server error has occured</response>
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<BaseResponse>> UpdateProduct(UpdateProductRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Deletes an existing product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Delete
        ///     {
        ///         "sku": 43264
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Sku, name and time of deletion of deleted product</returns>
        /// <response code="200">Returns the deleted product</response>
        /// <response code="404">Product with this sku identifier could not be found</response>
        /// <response code="500">An internal server error has occured</response>
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<BaseResponse>> DeleteProduct(DeleteProductRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
