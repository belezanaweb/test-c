using System;
using System.Collections.Generic;
using testc.Model;

namespace testc.Business
{
    public interface IWarehouseBusiness
    {
        Warehouse Create(Warehouse warehouse);
        Warehouse Update(Warehouse warehouse);
        List<Warehouse> GetAll();
    }
}
