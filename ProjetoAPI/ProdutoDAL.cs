using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ProdutoDAL
    {

        public int calcularQuantity(Produto p)
        {
            int total = 0;
            List<Warehouse> lista = new List<Warehouse>();

            lista = p.inventory.warehouses;

            foreach (Warehouse w in lista)
            {
                total += w.quantity;
            }

            return total;

        }
        public List<Produto> retornaListaProdutos()
        {
            List<Produto> lista = new List<Produto>();

            var json = File.ReadAllText(@"C:\Users\Sebek\source\repos\WebAPI\produto.json");
            Root root = JsonConvert.DeserializeObject<Root>(json);
            lista = root.produtos;

            return lista;
        }
        
        public void atualizaArquivo(List<Produto> produtos)
        {
            String arquivo = @"C:\Users\Sebek\source\repos\WebAPI\produto.json";

            FileInfo arq_delete = new FileInfo(arquivo);
            arq_delete.Delete();

            Root root = new Root();
            root.produtos = produtos;
            string dados = JsonConvert.SerializeObject(root);

            File.WriteAllText(arquivo, dados);




            

        }

    }
}