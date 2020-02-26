using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Produto.Models;
using WebAPI_Produto.Repository;
using WebAPI_Produto.Service;

namespace WebAPI_Produto.Controllers
{
    public class ProdutosController : ApiController
    {
        private IProdutoService _service;

        public ProdutosController()
        {
            _service = new ProdutoService();
        }

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        public HttpResponseMessage Get()
        {
            var produto = _service.GetProduto();

            return Request.CreateResponse(produto);
        }

        public HttpResponseMessage Get(int id)
        {
            Produto item = _service.GetProduto(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        public async Task<HttpResponseMessage> Post()
        {
            string result = await Request.Content.ReadAsStringAsync();

            Produto item = JsonConvert.DeserializeObject<Produto>(result);

            item = _service.CriaProduto(item);

            if (item == null)
            {
                var message = string.Format("Dois produtos são considerados iguais se os seus skus forem iguais");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
            }

            return Request.CreateResponse(HttpStatusCode.Created, item);
        }

        public async Task<HttpResponseMessage> Put(int id)
        {
            string result = await Request.Content.ReadAsStringAsync();

            Produto item = JsonConvert.DeserializeObject<Produto>(result);

            item = _service.AtualizaProduto(id, item);

            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        public HttpResponseMessage Delete(int id)
        {
            Produto item = _service.GetProduto(id);

            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (!_service.RemoveProduto(id)){

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

