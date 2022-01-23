namespace Boticario.API.Models
{
    public class CreateProduct
    {
        public CreateProduct(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
    }
}
