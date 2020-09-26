using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities.Impl
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
            : this(sku, name, null)
        { }

        public Product(long sku, string name, ICollection<Warehouse> warehouses)
        {
            Sku = sku;
            Name = name;
            Warehouses = warehouses;
        }

        #endregion
    }
}
