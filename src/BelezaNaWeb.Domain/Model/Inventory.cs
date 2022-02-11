namespace BelezaNaWeb.Domain.Model
{
    public class Inventory
    {
        public Inventory()
        {
            //Quantity = 0;
            Warehouses = new List<Warehouse>();
        }

        public Inventory(List<Warehouse> warehouses)
        {
            //Quantity = quantity;
            Warehouses = warehouses;
        }

        public int Quantity { get { return Warehouses.Sum(x => x.Quantity); } }

        public List<Warehouse> Warehouses { get; set; }

        //public void CalculateQuantity()
        //{
        //    this.Quantity = this.Warehouses.Sum(x => x.Quantity);
        //}
    }
}
