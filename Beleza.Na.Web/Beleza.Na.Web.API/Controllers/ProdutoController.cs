using Beleza.Na.Web.AppicationServer;
using Beleza.Na.Web.AppicationServer.Interfaces;
using Beleza.Na.Web.Domain;
using Beleza.Na.Web.Repository;
using System.Threading.Tasks;
using System.Web.Http;

namespace Beleza.Na.Web.API.Controllers
{
    [RoutePrefix("api/v1/produto")]
    [Authorize]
    public class ProdutoController : ApiController
    {
        private readonly IProductService _productService;

        // Usaria um framework de injeção de dependência no construtor.
        //public ProdutoController(IProductService productService)
        //{
        //    _productService = productService;
        //}

        public ProdutoController()
        {
            _productService = new ProductService(new ProductRepository());
        }

        public async Task<IHttpActionResult> Post([FromBody] ProductDomain product)
        {
            bool insertIsOk = await Task.FromResult(_productService.CreateProduct(product));

            if (!insertIsOk)
            {
                return BadRequest();
            }

            return Ok();
        }

        public async Task<IHttpActionResult> Put([FromBody] ProductDomain product)
        {
            bool UpdateIsOk = await Task.FromResult(_productService.UpdateProduct(product));

            if (!UpdateIsOk)
            {
                return BadRequest();
            }

            return Ok();
        }

        public async Task<IHttpActionResult> Get([FromUri] int sku)
        {
            ProductDomain product = await Task.FromResult(_productService.GetProduct(sku));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        public async Task<IHttpActionResult> Delete([FromUri] int sku)
        {
            bool deleteIsOk = await Task.FromResult(_productService.DeleteProduct(sku));

            if (!deleteIsOk)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
