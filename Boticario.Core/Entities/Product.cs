namespace Boticario.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
            IsMarketable = false;
        }

        public int Sku { get; private set; }
        public string Name { get; private set; }
        public bool IsMarketable { get; private set; }
    }
}
