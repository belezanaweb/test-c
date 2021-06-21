using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrupoBoticario.API.Data;
using GrupoBoticario.API.Models;
using GrupoBoticario.API.Services.IServices;

namespace GrupoBoticario.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProdutoService _produtoService;

        public ProdutoController(DataContext context, 
            IProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
        }         

        // GET: api/Produto
       // [HttpGet]
       // public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
       // {
       //     return await _context.Produtos.ToListAsync();
       // }

        // GET: api/Produto/5
        [HttpGet]
        [Route("{sku:int}")]
        public async Task<ActionResult<List<Produtos>>> ListBySku(int sku)
        {
            //var product = await _context.Produtos.FindAsync(sku);
            var product = await _produtoService.ListBySku(sku);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("{sku:int}")]
        public async Task<IActionResult> PutProduct(int sku, [FromBody] Produtos produto)
        {
            if (sku != produto.Sku)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                // await _context.SaveChangesAsync();
                await _produtoService.UpdateBySku(produto);
                return Ok(value: produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(sku))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }
       

        // POST: api/Produto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produtos>> CreateBySku(Produtos produto)
        {
            //_context.Produtos.Add(produto);
            //await _context.SaveChangesAsync();
            await _produtoService.CreateBySku(produto);

            return CreatedAtAction("ListBySku", routeValues: new { sku = produto.Sku }, produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete]
        [Route("{sku:int}")]
        public async Task<ActionResult<Produtos>> DeleteBySku(int sku)
        {
            //var product = await _context.Produtos.FindAsync(sku);
            var product = await _produtoService.ProdutoBySku(sku);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                //_context.Produtos.Remove(product);
                //await _context.SaveChangesAsync();
                await _produtoService.DeleteBySku(product);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        private bool ProductExists(int sku)
        {
            return _context.Produtos.Any(e => e.Sku == sku);
        }
      
    }
}
