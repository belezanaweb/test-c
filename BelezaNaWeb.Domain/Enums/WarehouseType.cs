using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Enums
{
    public class WarehouseType : Enum
    {
        public static WarehouseType eCommerce = new WarehouseType(1, "ECOMMERCE");
        public static WarehouseType physicalStore = new WarehouseType(2, "PHYSICAL_STORE");

        public WarehouseType(int id, string name) : base (id, name) { }
    }
}
