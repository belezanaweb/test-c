using DemoTest.AppService.Application.Interface;
using DemoTest.AppService.Application.Produto.DTO;
using DemoTest.Domain.Entities.Constants;
using DemoTest.Domain.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoTest.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this.produtoAppService = produtoAppService;
        }

        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        /// <param name="request">Produto Request</param>
        /// <returns>Objeto produto criado</returns>
        [HttpPost]        
        public ActionResult Cadastrar(ProdutoRequest request)
        {
            ProdutoResponse resultado = new ProdutoResponse();

            try
            {
                resultado = produtoAppService.Adicionar(request);
            }
            catch (ProdutoJaCadastradoExcecao ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Quando existe um sistema de log ELK usa-se um filter
                // logger.log(<EventoException>, ex);
                return StatusCode(500, ProdutoConstants.MsgErroInternoCaastrarProduto);
            }

            return Ok(resultado);
        }

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        /// <param name="request">Produto Request</param>
        /// <returns>Objeto produto atualizado</returns>
        [HttpPut]
        public ActionResult Atualizar(ProdutoRequest request)
        {
            ProdutoResponse resultado = new ProdutoResponse();

            try
            {
                resultado = produtoAppService.Atualizar(request);
            }
            catch (ProdutoNaoCadastradoExcecao ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Quando existe um sistema de log ELK usa-se um filter
                // logger.log(<EventoException>, ex);
                return StatusCode(500, ProdutoConstants.MsgErroInternoAtualizarProduto);
            }

            return Ok(resultado);
        }

        /// <summary>
        /// Método para recuperar produto
        /// </summary>
        /// <param name="sku">Codigo sku do produto</param>
        /// <returns>Objeto produto</returns>
        [HttpGet("{sku}")]
        public ActionResult Recuperar(long sku)
        {
            ProdutoResponse resultado = new ProdutoResponse();

            try
            {
                resultado = produtoAppService.RetornarPorSku(sku);
            }
            catch (ProdutoNaoCadastradoExcecao ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Quando existe um sistema de log ELK usa-se um filter
                // logger.log(<EventoException>, ex);
                return StatusCode(500, ProdutoConstants.MsgErroInternoConsultarProduto);
            }

            return Ok(resultado);
        }

        /// <summary>
        /// Método que deleta um produto
        /// </summary>
        /// <param name="sku">Codigo sku do produto</param>        
        [HttpDelete("{sku}")]
        public ActionResult Deletar(long sku)
        {
            ProdutoResponse resultado = new ProdutoResponse();

            try
            {
                produtoAppService.Deletar(sku);
            }
            catch (ProdutoNaoCadastradoExcecao ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Quando existe um sistema de log ELK usa-se um filter
                // logger.log(<EventoException>, ex);
                return StatusCode(500, ProdutoConstants.MsgErroInternoDeletarProduto);
            }

            return Ok();
        }
    }
}
