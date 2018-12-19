using System;
using testc.Model.Base;

namespace testc.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }

    }
}
