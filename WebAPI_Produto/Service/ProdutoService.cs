using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Produto.Models;
using WebAPI_Produto.Repository;

namespace WebAPI_Produto.Service
{
    public class ProdutoService : IProdutoService
    {
        static readonly IProdutoRepository _repository = new ProdutoRepository();

        protected Produto ValidaProduto(Produto produto)
        {

            produto.inventory.quantity = produto.inventory.warehouses.Select(i => i.quantity).Sum();

            produto.isMarketable = produto.inventory.quantity == 0 ? false : true;


            return produto;
        }

        public Produto GetProduto(int sku)
        {
            Produto item = null;

            try
            {
                var produto = _repository.Get(sku);

                produto = ValidaProduto(produto);

                item = produto;

            }
            catch
            {
                return item;
            }
            return item;
        }

        public List<Produto> GetProduto()
        {
            List<Produto> MeuProdutos = new List<Produto>();            

            try
            {
                MeuProdutos.AddRange(_repository.GetAll());

                MeuProdutos.ForEach(item => ValidaProduto(item));
            }
            catch
            {
                return MeuProdutos;
            }

            return MeuProdutos;
        }

        public Produto CriaProduto(Produto produto)
        {
            Produto novoProduto = null;

            produto = ValidaProduto(produto);

            try
            {
                novoProduto = _repository.Add(produto);
            }
            catch
            {
                return novoProduto;
            }
            return novoProduto;
        }

        public Produto AtualizaProduto(int id, Produto produto)
        {
            Produto novoProduto = null;

            produto = ValidaProduto(produto);

            try
            {
                novoProduto = _repository.Update(id, produto);
            }
            catch
            {
                return novoProduto;
            }
            return novoProduto;
        }

        public bool RemoveProduto(int id)
        {                                 
            try
            {
                _repository.Remove(id);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}