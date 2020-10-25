namespace Boticario.Backend.Modules.Products.Models
{
    public interface IProductInventoryDetails
    {
        string Locality { get; }
        long Quantity { get; }
        string Type { get; }
    }
}
