namespace BelezaNaWeb.Domain.Produtos
{
    public class Warehouse
    {
        public int Id { get; private set; }

        public string Locality { get; set; }

        public long Quantity { get; set; }

        public string Type { get; set; }
    }
}
