namespace Boticario.Backend.Modules.Inventory.Models
{
    public interface IInventory
    {
        int Sku { get; }
        string Locality { get; }
        int Quantity { get; }
        string Type { get; }
    }
}
