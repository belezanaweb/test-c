namespace BelezaNaWeb.Domain.Produtos
{
    public class Produto
    {

        public long Sku { get; private set; }

        public string Name { get; private set; }

        public Inventory Inventory { get; private set; }

        public bool? IsMarketable { get; private set; }

        public void CalcularInventoryQuantity()
        {
            if (Inventory != null)
                Inventory.CalcularQuantity();
        }

        public void CalcularIsMarketable()
        {
            if (Inventory != null)
                this.IsMarketable = Inventory.Quantity > 0;
        }
    }
}
