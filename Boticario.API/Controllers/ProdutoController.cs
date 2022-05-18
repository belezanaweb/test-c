using Boticario.Application.Interfaces;
using Boticario.Core.Model.Commands.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boticario.API.Controllers
{
    [ApiController, Route("API/[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{sku:long}")]
        public async Task<IActionResult> Obter(long sku)
        {
            var resultado = await _produtoService.ObterPorSKU(sku);

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _produtoService.Listar();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(InserirProdutoCommand produto)
        {
            var resultado = await _produtoService.Inserir(produto);

            if(resultado.Sucesso)
            {
                return Ok();
            }

            return BadRequest(resultado.Erros);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(AtualizarProdutoCommand produto)
        {
            var resultado = await _produtoService.Atualizar(produto);

            if (resultado.Sucesso)
            {
                return Ok();
            }

            return BadRequest(resultado.Erros);
        }

        [HttpDelete("{sku:long}")]
        public async Task<IActionResult> Excluir(long sku)
        {
            var resultado = await _produtoService.Excluir(sku);

            if (resultado.Sucesso)
            {
                return Ok();
            }

            return BadRequest(resultado.Erros);
        }
    }
}
