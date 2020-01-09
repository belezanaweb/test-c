using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using TesteC.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Net;

namespace TesteC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary TempData { get; set; }
        private IMemoryCache _cache;

        public ProdutoController(IMemoryCache cache)
        {
            _cache = cache;
        

        [HttpGet]
        public ActionResult<string> Buscar(int sku)
        {
            var produto = new ProdutoModel();


            if (!_cache.TryGetValue("ProdutoIm", out produto))
            {
                if (produto == null)
                {
                    return "Produto não existe";
                }

                foreach (var item in produto.invetory.warehouses)
                {
                    produto.invetory.quantity = produto.invetory.quantity + item.quantity;
                }

                produto.isMarketable = produto.invetory.quantity > 0;

                var serializer = new JsonSerializer();
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, produto);
                    return textWriter.ToString();
                }

            }

            return "";
        }

        // POST api/Produto
        public HttpResponseMessage Gravar(ProdutoModel produto)
        {
            var produtoIm = new ProdutoModel();

            if (!_cache.TryGetValue("ProdutoIm", out produtoIm))
            {
                if (produtoIm == null)
                {
                    produtoIm = produto;
                }

                if (produtoIm.sku != produto.sku)
                {
                    _cache.Set("ProdutoIm", produtoIm);
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/Produto/5
        public void Alterar(ProdutoModel produto)
        {
            var produtoIm = new ProdutoModel();

            if (!_cache.TryGetValue("ProdutoIm", out produtoIm))
            {
                _cache.Set("ProdutoIm", produto);
            }

        }

        // DELETE api/Produto/5
        public void Excluir(int sku)
        {
            var produtoIm = new ProdutoModel();

            if (!_cache.TryGetValue("ProdutoIm", out produtoIm))
            {
                if (produtoIm != null && produtoIm.sku == sku)
                {
                    _cache.Set("ProdutoIm", new ProdutoModel());
                }
            }
        }
    }
}

