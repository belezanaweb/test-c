namespace TesteBoticario.Domain.Dto
{
    public class Product
    {
        //public Product(int sku, string name, Inventory inventory)
        //{
        //    Sku = sku;
        //    Name = name;
        //    Inventory = inventory;
        //}

        public int Sku { get; set; }
        
        public string Name { get; set; }
        
        public Inventory Inventory { get; set; }
        
        public bool IsMarketable => Inventory.Quantity > 0;
    }
}