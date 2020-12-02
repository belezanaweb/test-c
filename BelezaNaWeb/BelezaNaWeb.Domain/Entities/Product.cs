namespace BelezaNaWeb.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }

        #region Construtores 

        public Product() { }

        public Product(int sku, string name, Inventory inventory, bool isMarketable)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
            IsMarketable = isMarketable;
        }

        #endregion
    }
}