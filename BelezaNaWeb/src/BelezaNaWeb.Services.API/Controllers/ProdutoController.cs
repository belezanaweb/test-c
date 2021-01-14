using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult> Adicionar(ProdutoViewModel produtoView)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.Select(x => x.Errors));

            var ret = await _produtoAppService.Adicionar(produtoView);

            if (ret.Validacao.Errors.Any())
                return BadRequest(ret.Validacao.Errors);

            return Ok(ret);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar(ProdutoViewModel produtoView)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.Select(x => x.Errors));

            var ret = await _produtoAppService.Atualizar(produtoView);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterPorSku")]
        public async Task<ActionResult> ObterPorSku(long sku)
        {
            var ret = await _produtoAppService.ObterPorSku(sku);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpDelete]
        [Route("RemoverPorSku")]
        public async Task<ActionResult> RemoverPorSku(long sku)
        {
            var ret = _produtoAppService.RemoverPorSku(sku);

            if (ret == null)
                return NotFound();

            return Ok();
        }
    }
}
