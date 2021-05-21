using BelezaNaWebAvaliacao.DataAccess;
using BelezaNaWebAvaliacao.Product.Business.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using models = BelezaNaWebAvaliacao.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BelezaNaWebAvaliacao.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //private readonly IMapper _mapper;
        private readonly ProductBusinessLogic productBusinesslogic;

        public ProductController(DataContext context)
        {
            //_mapper = mapper;
            productBusinesslogic = new ProductBusinessLogic(context);
        }

        /// <summary>
        /// Get a product by your sku code
        /// </summary>
        /// <param name="sku"></param>
        /// <returns>A Product in Json format</returns>
        [HttpGet]
        [Route("{sku:int}")]
        public async Task<IActionResult> Get([FromServices] DataContext context, int sku)
        {

            var retGet = await productBusinesslogic.GetProduct(sku);

            if (retGet == null)
            {
                return BadRequest(retGet);
            }

            return Ok(retGet);
        }

        /// <summary>
        /// Create a new product 
        /// </summary>
        /// <param name="product">A product in Json format</param>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(
            [FromServices] DataContext context,
            [FromBody] models.Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto enviado é inválido");
            }
            else
            {

                var retCreate = await productBusinesslogic.CreateProduct(product);

                if (retCreate != "ok")
                {

                    if (retCreate == "Já existe produto com o sku informado!")
                    {
                        return BadRequest(retCreate);
                    }
                    else
                    {
                        return Problem(retCreate, "Procuct/Post", 500);
                    }

                }

            }

            return Ok("Ação realizada com sucesso!"); ;
        }

        /// <summary>
        /// Modify a existent product per new product sent
        /// </summary>
        /// <param name="sku">A sku code</param>
        /// <param name="product">The data of a new product in Json format</param>
        [HttpPut]
        [Route("{sku:int}")]
        public async Task<IActionResult> Put([FromServices] DataContext context, [FromBody] models.Product product, int sku)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto enviado é inválido");
            }

            var retUpdate = await productBusinesslogic.UpdateProduct(product, sku);

            return Ok("Ação realizada com sucesso!");

        }

        /// <summary>
        /// Remove a product per sku code 
        /// </summary>
        /// <param name="sku">A sku code</param>
        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<IActionResult> Delete([FromServices] DataContext context, int sku)
        {
            try
            {
                var retDelete = await productBusinesslogic.DeleteProduct(sku);

                if (retDelete != "ok")
                {
                    return BadRequest(retDelete);
                }

                return Ok("Ação realizada com sucesso!");
            }
            catch (System.Exception)
            {
                return Problem("Ocorreu um erro inesperado, tente novamente!","Product/Delete",500);
            }

        }
    }
}
