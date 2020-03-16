using BelezaNaWeb.Domain.Core.Models;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Models
{
    public class Warehouse : Entity
    {
        public Warehouse(string locality, string type) : this()
        {
            Locality = locality;
            Type = type;
        }

        protected Warehouse() 
        {
            Inventory = new HashSet<Inventory>();
        }

        public string Locality { get; private set; }
        public string Type { get; private set; }
        public ICollection<Inventory> Inventory { get; private set; }
    }
}
