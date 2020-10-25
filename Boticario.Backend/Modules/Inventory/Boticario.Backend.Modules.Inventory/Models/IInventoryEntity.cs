namespace Boticario.Backend.Modules.Inventory.Models
{
    public interface IInventoryEntity
    {
        string Locality { get; }
        long Quantity { get; }
        string Type { get; }
    }
}
