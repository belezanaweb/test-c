using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_beauty.Models;

namespace web_beauty.Data
{
    public class Context : IContext
    {
        private readonly IMongoDatabase database;

        public Context(string port, string host)
        {
            database = new MongoClient($"mongodb://{host}:{port}").GetDatabase("Ecommerce");
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return database.GetCollection<Product>("Products");
            }
        }
    }
}
