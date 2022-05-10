using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Data
{
    public class AppDbContext
    {
        internal readonly Dictionary<string, dynamic> Database;

        internal List<T> Set<T>() where T : BaseEntity
        {
            return Database[typeof(T).Name];
        }

        public AppDbContext()
        {
            this.Database = new Dictionary<string, dynamic>();
        }

        internal void CreateDatabase<T>() where T : BaseEntity
        {
            var name = typeof(T).Name;
            if (!Database.ContainsKey(name))
                Database.Add(name, new List<T>());
        }



    }
}
