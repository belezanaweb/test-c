using BelezaNaNet.Api.Commands;
using BelezaNaNet.Api.ValueObjects;
using System.Collections.Generic;

namespace BelezaNaNet.Api.Inputs
{
    public class CreateProductInput
    {
        public double Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
    public class UpdateProductInput
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
