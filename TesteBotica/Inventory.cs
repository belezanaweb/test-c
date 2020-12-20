using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    public Inventory() { }
    public List<Warehouse> Warehouses { get; set; }
    public int Quantity { get { return Warehouses.Sum(x => x.Quantity); } }
}
