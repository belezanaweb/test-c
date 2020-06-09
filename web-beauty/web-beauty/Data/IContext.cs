using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_beauty.Models;

namespace web_beauty.Data
{
    public interface IContext
    {       
        IMongoCollection<Product> Products { get; }
    }
}
