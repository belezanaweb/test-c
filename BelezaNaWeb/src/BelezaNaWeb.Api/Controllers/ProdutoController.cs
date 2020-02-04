using BelezaNaWeb.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarProdutoPorSku(long sku)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarProduto(ProdutoViewModel produtoViewModel)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> EditarProduto(long sku)
        {
            return Ok();
        }
    }
}
