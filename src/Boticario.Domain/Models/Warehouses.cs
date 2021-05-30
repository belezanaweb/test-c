namespace Boticario.Domain.Models
{
    public class Warehouses
    {
        public Warehouses(string locality, string type)
        {
            this.Locality = locality;
            this.Type     = type;
        }

        public void IncreaseQuantity(double quant)
        {
            this.Quantity += quant;
        }

        public void DecreaseQuantity(double quant)
        {
            this.Quantity -= quant;
        }

        public string Locality { get; private set; }
        public double Quantity { get; private set; }
        public string  Type { get; private set; }
    }
}
