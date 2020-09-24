using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities
{
    [Serializable]
    [DataContract]
    public class Product : Entity
    {
        #region Public Properties

        [DataMember]
        public long Sku { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<Warehouse> Warehouses { get; set; }

        #endregion

        #region Constructors

        public Product()
        { }

        public Product(long sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        #endregion
    }
}
