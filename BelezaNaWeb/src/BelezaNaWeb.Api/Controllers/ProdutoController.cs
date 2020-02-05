using BelezaNaWeb.Service.Interfaces;
using BelezaNaWeb.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutoController( IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [HttpPost]

        public async Task<IActionResult> CriarProdutoPorSku(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel  == null)
                return BadRequest();

            try
            {
                await produtoService.AddAsync(produtoViewModel);
                return Ok("Produto criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpGet("{sku}")]
        public async Task<IActionResult> RecuperarProdutoPorSku(long sku)
        {
            if (sku == 0)
                return BadRequest();
            try
            {
                var produto = await produtoService.GetBySku(sku);
                if (produto == null)
                    return Ok("Produto não encontado!");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> EditarProduto(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel == null)
                return BadRequest();
            try
            {
                await produtoService.Update(produtoViewModel);
                return Ok("Produto editado com sucesso!");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Não é possivel editar um produto cuja o SKU:{produtoViewModel.Sku} ainda não foi cadastrado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{sku}")]
        public async Task<IActionResult> DeletarProduto(long sku)
        {
            if (sku == 0)
                return BadRequest();
            try
            {
                await produtoService.Deletar(sku);
                return Ok($"Produto com sku:{sku}, deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
