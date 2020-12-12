using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        public static List<Produto> listaProdutos = new List<Produto>();
        ProdutoDAL dal = new ProdutoDAL();


        [AcceptVerbs("GET")]
        [Route("recuperarProdutoPorSku/{sku}")]
        public HttpResponseMessage RecuperarProdutoPorSku(int sku)
        {
            listaProdutos = dal.retornaListaProdutos();

            bool isMarketable = false;

            Produto p = listaProdutos.FirstOrDefault(a => a.sku == sku);

            if (p == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Produto de sku " + sku + " não localizado");
            }
            else
            {
                p.inventory.quantity = dal.calcularQuantity(p);

                if (p.inventory.quantity > 0)
                {
                    isMarketable = true;
                }

                p.isMarketable = isMarketable;
                //retorno = JsonConvert.SerializeObject(p);
                return Request.CreateResponse(HttpStatusCode.OK, p);

            }

        }


        [AcceptVerbs("DELETE")]
        [Route("deletarProdutoPorSku/{sku}")]
        public HttpResponseMessage DeletarProdutoPorSku(int sku)
        {

            listaProdutos = dal.retornaListaProdutos();

            Produto p = listaProdutos.FirstOrDefault(a => a.sku == sku);


            if (p == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Produto de sku " + sku + " não localizado");
            }
            else
            {
                listaProdutos.RemoveAll(a => a.sku == sku);
                dal.atualizaArquivo(listaProdutos);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto de sku " + sku + " deletado");

            }

        }

        [AcceptVerbs("PUT")]
        [Route("alterarProdutoPorSku/")]
        public HttpResponseMessage AlterarProdutoPorSku(JObject prod)
        {

            listaProdutos = dal.retornaListaProdutos();
            Produto p = JsonConvert.DeserializeObject<Produto>(prod.ToString());


            if (listaProdutos.FindIndex(a => a.sku == p.sku)==null)
            {
                 return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Produto " + p.sku + " não localizado");
            }
            else
            {
                int index = listaProdutos.FindIndex(a => a.sku == p.sku);
                listaProdutos[index] = p;
                dal.atualizaArquivo(listaProdutos);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto " + p.sku + " alterado ");
            }

        }

        [AcceptVerbs("POST")]
        [Route("cadastrarProduto/")]
        public HttpResponseMessage CadastrarProduto(JObject prod)
        {

            listaProdutos = dal.retornaListaProdutos();
            Produto p = JsonConvert.DeserializeObject<Produto>(prod.ToString());

            if(listaProdutos.FindIndex(a => a.sku == p.sku)<0)
            {
                listaProdutos.Add(p);
                dal.atualizaArquivo(listaProdutos);

                return Request.CreateResponse(HttpStatusCode.OK,"Produto Cadastrado com Sucesso!!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Ambiguous,"Já existe um produto cadastrado com o sku "+p.sku);

            }




        }


    
        }

        

    



}
