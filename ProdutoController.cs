using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TesteWebApi.Models;

namespace WebAPI.Controllers
{

    [RoutePrefix("api")]
    public class ProdutoController : ApiController
    {
        private static List<ProdutoModels> ListaProdutos = new List<ProdutoModels>();

        [AcceptVerbs("POST")]
        [Route("Produto")]
        public string CadastrarProduto(ProdutoModels produto)
        {

            ProdutoModels produto_ = ListaProdutos.Where(n => n.sku == produto.sku)
                                                .Select(n => n)
                                                .First();

            if (produto_ != null)
            {
                return "Produto já cadastrado!";
            }


            ListaProdutos.Add(produto);

            return "Produto cadastrado com sucesso!";

        }

        [AcceptVerbs("PUT")]
        [Route("Produto")]
        public string AlterarProduto(ProdutoModels produto)
        {

            ListaProdutos.Where(n => n.sku == produto.sku)
                         .Select(s =>
                         {
                             s.sku = produto.sku;
                             s.name = produto.name;
                             return s;
                         }).ToList();

            return "Produto alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("Produto/{codigo}")]
        public string ExcluirProduto(int codigo)
        {

            ProdutoModels produto = ListaProdutos.Where(n => n.sku == codigo)
                                                .Select(n => n)
                                                .First();
            ListaProdutos.Remove(produto);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("Produto/{codigo}")]
        public ProdutoModels ConsultarProdutoPorCodigo(int codigo)
        {

            ProdutoModels produto = ListaProdutos.Where(n => n.sku == codigo)
                                                .Select(n => n)
                                                .FirstOrDefault();


            if (produto.Inventory != null)
            {
                if (produto.Inventory.WarehouseModels.Any())
                {
                    produto.Inventory.Quantity = produto.Inventory.WarehouseModels.Sum(x => x.Quantity);
                    if (produto.Inventory.Quantity > 0)
                    {
                        produto.IsMarketable = true;
                    }
                    else
                    {
                        produto.IsMarketable = false;
                    }
                }
            }
            return produto;
        }

    }
}
