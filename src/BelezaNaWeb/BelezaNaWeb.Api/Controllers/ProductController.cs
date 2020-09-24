using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Api.Contracts.Responses;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/products")]    
    public sealed class ProductController : GenericController
    {
        #region Constructors

        public ProductController(ILogger<ProductController> logger, IMapper mapper)
            : base(logger, mapper)
        { }

        #endregion

        #region Controller Actions

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List([FromServices] IProductRepository repository)
        {

            var collection = await repository.GetAll();

            return Ok(collection);
        }


        #endregion
    }
}
