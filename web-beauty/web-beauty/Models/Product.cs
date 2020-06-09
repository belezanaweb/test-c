
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_beauty.Models {
    public class Product
    {
        public Product()
        {
            Inventory = new Inventory();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}