using BelezaNaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BelezaNaWeb.Database;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Controllers
{
    [ApiController]
    [Route("api/Produtos")]
    public class ProdutosController : Controller
    {

        private readonly BelezaNaWebContext _context;

        public ProdutosController(BelezaNaWebContext context)
        {
            _context = context;
        }


        [HttpGet("{sku}", Name ="Get")]
        public ActionResult Get(int sku)
        {

            var produtos = _context.Produtos.AsNoTracking()
                                 .Include(i => i.inventory)
                                 .Include(w => w.inventory.warehouses)
                                 .ToList();

            var produto = produtos.Where(p => p.sku == sku).FirstOrDefault();
            if (produto == null)
                return NotFound();

            _context.Dispose();
            return Ok(produto);

        }

        [HttpPost]
        public ActionResult Add([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest();

            if (produto.sku == 0)
                return BadRequest("Sku é obrigatório");

            
            var produtoexiste = _context.Produtos.Where(p => p.sku == produto.sku).FirstOrDefault();
            if (produtoexiste != null)
                return BadRequest("Produto com sku já cadastrado");


            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Created($"api/belezanaweb/Produtos/{produto.sku}", produto);
        }

        [HttpPut("{sku}", Name ="Put")]
        public ActionResult Change(int sku, [FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest();

            var produtos = _context.Produtos.AsNoTracking()
                                 .Include(i => i.inventory)
                                 .Include(w => w.inventory.warehouses)
                                 .ToList();

            var produtoParaAtualizar = produtos.Where(p => p.sku == sku).FirstOrDefault();
            if (produtoParaAtualizar == null)
                return NotFound();


            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return Ok(produtoParaAtualizar);
        }

        [HttpDelete("{sku}", Name = "Delete")]
        public ActionResult Delete(int sku)
        {
            var produtos = _context.Produtos.AsNoTracking()
                                            .Include(i => i.inventory)
                                            .Include(w => w.inventory.warehouses)
                                            .ToList();

            var produtoParaExcluir = produtos.Where(p => p.sku == sku).FirstOrDefault();
            if (produtoParaExcluir == null)
                return NotFound();

            _context.Produtos.Remove(produtoParaExcluir);
            _context.SaveChanges();
            
            return NoContent();

        }
    }
}
