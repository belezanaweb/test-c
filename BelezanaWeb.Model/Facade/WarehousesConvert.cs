using System.Collections.Generic;
using System.Linq;

namespace BelezanaWeb.Model.Facade
{
    public class WarehouseConvert
    {
        public static Warehouse ToModel(WarehouseMessage input)
        {
            var output = new Warehouse();

            output.Id = input.Id;
            output.Locality = input.Locality;
            output.Quantity = input.Quantity;
            output.Type = input.Type;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public static WarehouseMessage ToMessage(Warehouse input)
        {
            var output = new WarehouseMessage();

            output.Id = input.Id;
            output.Locality = input.Locality;
            output.Quantity = input.Quantity;
            output.Type = input.Type;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public static List<Warehouse> ToModel(ICollection<WarehouseMessage> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<Warehouse>();

            foreach (var input in inputs)
            {
                var output = new Warehouse();

                output.Id = input.Id;
                output.Locality = input.Locality;
                output.Quantity = input.Quantity;
                output.Type = input.Type;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

        public static List<WarehouseMessage> ToMessage(ICollection<Warehouse> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<WarehouseMessage>();

            foreach (var input in inputs)
            {
                var output = new WarehouseMessage();

                output.Id = input.Id;
                output.Locality = input.Locality;
                output.Quantity = input.Quantity;
                output.Type = input.Type;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

    }
}
