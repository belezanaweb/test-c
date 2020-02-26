using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Produto.Models;

namespace WebAPI_Produto.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> produtos = new List<Produto>();
        
        public ProdutoRepository()
        {
            //Add(new Produto
            //{
            //    sku = 43264,
            //    name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            //    inventory = new Inventory() {
            //        werehouses = new List<Werehouse>
            //        {
            //            new Werehouse{
            //                locality = "SP", quality = 12, type = "ECOMMERCE"
            //            },
            //            new Werehouse{
            //                locality = "MOEMA", quality = 3, type = "PHYSICAL_STORE"
            //            }
            //        }
            //    }
            //});
        }

        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Produto não localizado.");

            }else if (produtos.Any(x => x.sku == item.sku))
            {
                return null;
            }
            
            produtos.Add(item);
            return item;
        }

        public Produto Get(int sku)
        {
            return produtos.Find(p => p.sku == sku);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int sku)
        {
            produtos.RemoveAll(p => p.sku == sku);
        }

        public Produto Update(int sku, Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Pruduto não pode ser nulo.");
            }

            int index = produtos.FindIndex(p => p.sku == sku);

            if (index == -1)
            {
                throw new ArgumentNullException("Produto não localizado.");
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return item;
        }
    }
}