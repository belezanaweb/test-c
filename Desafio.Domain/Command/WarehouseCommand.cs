namespace Desafio.Domain.Command
{
    public abstract class WarehouseCommand : Command
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }

}
