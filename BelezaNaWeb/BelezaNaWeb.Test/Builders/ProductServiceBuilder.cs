using BelezaNaWeb.Api.Model;

namespace BelezaNaWeb.Test.Builders
{
    public class ProductServiceBuilder
    {
        private int sku;
        private string name;
        private InventoryModel inventory;

        public static ProductServiceBuilder newProduct()
        {
            return new ProductServiceBuilder();
        }

        public ProductServiceBuilder WithSku(int sku)
        {
            this.sku = sku;
            return this;
        }

        public ProductServiceBuilder WithInvalidSku(int sku)
        {
            this.sku = sku;
            return this;
        }

        public ProductServiceBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ProductServiceBuilder Marketable(InventoryModel inventory)
        {
            this.inventory = inventory;
            return this;
        }

        public ProductServiceBuilder WithInventoryWithoutQuantity(InventoryModel inventory)
        {
            this.inventory = inventory;
            return this;
        }


        public ProductModel Build() => new ProductModel(sku, name, inventory);
    }
}
