using System.Collections.Generic;
using System.Linq;

namespace BelezanaWeb.Model.Facade
{
    public class ProductConvert
    {
        public static Product ToModel(ProductMessage input)
        {
            var output = new Product();

            output.Id = input.Id;
            output.Sku = input.Sku;
            output.Name = input.Name;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;
            output.Warehouses = WarehouseConvert.ToModel(input.Inventory.Warehouses);

            return output;
        }

        public static ProductMessage ToMessage(Product input)
        {
            var output = new ProductMessage();

            output.Id = input.Id;
            output.Sku = input.Sku;
            output.Name = input.Name;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;
            output.Inventory.Warehouses = WarehouseConvert.ToMessage(input.Warehouses);

            return output;
        }

        public static List<Product> ToModel(List<ProductMessage> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<Product>();  

            foreach (var input in inputs)
            {
                var output = new Product();  

                output.Id = input.Id;
                output.Sku = input.Sku;
                output.Name = input.Name;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;
                output.Warehouses = WarehouseConvert.ToModel(input.Inventory.Warehouses);

                outputs.Add(output);
            }

            return outputs;
        }

        public static List<ProductMessage> ToMessage(List<Product> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<ProductMessage>();  

            foreach (var input in inputs)
            {
                var output = new ProductMessage();  

                output.Id = input.Id;
                output.Sku = input.Sku;
                output.Name = input.Name;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;
                output.Inventory.Warehouses = WarehouseConvert.ToMessage(input.Warehouses);

                outputs.Add(output);
            }

            return outputs;
        }

    }
}
