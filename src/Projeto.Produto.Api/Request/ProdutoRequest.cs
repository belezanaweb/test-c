namespace Projeto.Produtos.Api.Request
{
    public class ProdutoRequest
    {
        public int Sku { get; set; }

        public string Nome { get; set; }

        public InventoryRequest Inventory { get; set; }
    }
}
