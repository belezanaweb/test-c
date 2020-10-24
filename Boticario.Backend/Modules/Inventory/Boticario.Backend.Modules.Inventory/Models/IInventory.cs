namespace Boticario.Backend.Modules.Inventory.Models
{
    public interface IInventory
    {
        string Locality { get; }
        int Quantity { get; }
        string Type { get; }
    }
}
