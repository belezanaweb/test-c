using System;
using System.Collections.Generic;
using testc.Model;

namespace testc.Business
{
    public interface IInventoryBusiness
    {
        Inventory Create(Inventory inventory);
        Inventory Update(Inventory inventory);
        List<Inventory> GetAll();
    }
}
