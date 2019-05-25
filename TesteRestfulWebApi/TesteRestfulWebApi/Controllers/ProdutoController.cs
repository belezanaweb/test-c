using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteRestfulWebApi.Models;

namespace TesteRestfulWebApi.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        public static List<ProdutoModel> listaProdutos = new List<ProdutoModel>();

        [HttpPost]
        [Route("CadastrarProduto")]
        public HttpResponseMessage CadastrarProduto(ProdutoModel produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("Lista de produtos vazia"));

            if (listaProdutos.Any(p => p.sku == produto.sku))
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("Produto com sku = {0} já existe na lista de produtos", produto.sku));

            listaProdutos.Add(produto);

            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto com sku = {0} incluído com sucesso!", produto.sku));
        }

        [HttpPut]
        [Route("AlterarProdutoPorSku/{sku:int}")]
        public HttpResponseMessage AlterarProdutoPorSku(int sku, ProdutoModel produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("Produto com sku = {0} não encontrado", sku));

            listaProdutos.Where(n => n.sku == sku)
                         .Select(p =>
                         {
                             p.name = produto.name;
                             return p;

                         }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto com sku = {0} alterado com sucesso!", produto.sku));
        }

        [HttpDelete]
        [Route("ExcluirProdutoPorSku/{sku:int}")]
        public HttpResponseMessage ExcluirProdutoPorSku(int sku, ProdutoModel produto)
        {
            produto = listaProdutos.Where(n => n.sku == sku)
                                                .Select(n => n)
                                                .FirstOrDefault();

            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("Produto com sku = {0} não encontrado", sku));

            listaProdutos.Where(n => n.sku == sku)
                .Select(n => n)
                .First();

            if (listaProdutos.Count > 0)
                listaProdutos.Remove(produto);

            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Produto com sku = {0} excluído com sucesso!", produto.sku));
        }

        [HttpGet]
        [Route("ConsultarProdutoPorSku/{sku}")]
        public HttpResponseMessage ConsultarProdutoPorSku(int sku)
        {
            ProdutoModel produto = listaProdutos.Where(n => n.sku == sku)
                                                .Select(n => n)
                                                .FirstOrDefault();

            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("Produto com sku = {0} não encontrado", sku));

            // Somatória das quantidades dos warehouses
            produto.inventory.quantity = 0;
            int iTotal = produto.inventory.warehouses.Sum(x => Convert.ToInt32(x.quantity));
            produto.inventory.quantity = iTotal;

            // Verifica se produto é marketable
            produto.isMarketable = false;
            if (produto.inventory.quantity > 0)
                produto.isMarketable = true;

            return Request.CreateResponse(HttpStatusCode.OK, produto);
        }
    }
}