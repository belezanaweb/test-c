using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_Boticario.Models
{
    public class Validate
    {
        public string message { get; set; }

        public string Product(Product p, int id = 0, List<Product> Products = null)
        {
            message = "";

            if (id != 0) //Validação do PUT
            {
                if (p.Sku != id) return message = "Não é permitido alterar o SKU existente";
            }

            if (Products != null && Products.Where(x => x.Sku == p.Sku).FirstOrDefault() != null) //Validação do POST
            {
                if (p.Sku == id) return message = "Dois produtos são considerados iguais se os seus skus forem iguais";
            }

            if (p == null) return message = "Algo deu errado. Verifique a documentação.";
            if (p.Sku == 0) return message = "SKU requirido, campo obrigatório.";
            if (String.IsNullOrEmpty(p.Name)) return message = "Name requirido, campo obrigatório.";
            return message;
        }
    }
}