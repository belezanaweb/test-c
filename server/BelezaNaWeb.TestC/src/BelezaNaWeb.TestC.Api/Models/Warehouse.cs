namespace BelezaNaWeb.TestC.Api.Models
{
    public class Warehouse
    {
        // Uma alternativa mais elegante seria criar um enum de Types e parsear o valor vindo como string.
        // Porém constantes resolvem bem o problema para o escopo do teste.
        public const string TYPE_ECOMMERCE_VALUE = "ECOMMERCE";
        public const string TYPE_PHYSICAL_STORE_VALUE = "PHYSICAL_STORE";

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
