using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Product
{
    public Product()
    {
    }

    public Product(int sku)
    {
        Sku = sku;
    }
    public Int64 Sku { get; set; }
    public string Name { get; set; }
    public Inventory Inventory { get; set; }
    public bool IsMarketable
    {
        get
        {
            if (Sku > 0)
                return Inventory.Quantity > 0;

            return true;
        }

    }
}
