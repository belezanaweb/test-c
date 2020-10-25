namespace Boticario.Backend.Modules.Products.Models
{
    public interface IProductDetails
    {
        int Sku { get; }
        string Name { get; }
        IProductInventory Inventory { get; }
        bool IsMarketable { get; }
    }
}
