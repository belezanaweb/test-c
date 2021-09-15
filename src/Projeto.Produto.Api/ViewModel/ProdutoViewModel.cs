namespace Projeto.Produtos.Api.ViewModel
{
    public class ProdutoViewModel
    {
        public int Sku { get; set; }

        public string Nome { get; set; }

        public bool IsMarketable { get; set; }

        public InventoryViewModel Inventory { get; set; }
    }
}
