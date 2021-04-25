namespace Boticario.Domain.Entities
{
    public class Product
    {
        #region Properties

        public uint Sku { get; set; }

        public string Name { get; set; }

        public Inventory Inventory { get; set; }

        public bool IsMarketable { get; set; }

        #endregion
    }
}