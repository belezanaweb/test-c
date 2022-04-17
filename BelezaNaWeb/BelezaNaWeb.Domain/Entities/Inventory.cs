namespace BelezaNaWeb.Domain.Entities
{
    public class Inventory
    {
        public int Quantity { get; }
        public List<Warehouse> Warehouses { get; }

        public Inventory(List<Warehouse> warehouses)
        {            
            this.Warehouses = warehouses;
            Quantity = SetQuantity(this.Warehouses);
        }

        private static int SetQuantity(IEnumerable<Warehouse> wh) => wh.Sum(item => item.Quantity);
    }
}