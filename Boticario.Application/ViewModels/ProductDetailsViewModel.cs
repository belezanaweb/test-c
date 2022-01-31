namespace Boticario.Application.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int sku, string name/*, int quantity*/, bool isMarketable)
        {
            Sku = sku;
            Name = name;
            //Quantity = quantity;
            IsMarketable = isMarketable;
        }
        public int Sku { get; private set; }
        public string Name { get; private set; }
        //public int Quantity { get; private set; }
        public bool IsMarketable { get; private set; }
    }
}
