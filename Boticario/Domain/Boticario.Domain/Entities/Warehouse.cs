﻿namespace Boticario.Domain.Entities
{
    public class Warehouse
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Warehouse() { }

        public Warehouse(string locality, int quantity, string type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

    }
}
