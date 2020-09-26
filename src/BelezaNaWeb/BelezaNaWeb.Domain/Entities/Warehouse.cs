using System;
using BelezaNaWeb.Domain.Enums;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities
{
    [Serializable]
    [DataContract]
    public class Warehouse: Entity
    {
        #region Public Properties
        
        [DataMember]
        public long Sku { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Locality { get; set; }

        [DataMember]
        public WarehouseTypes Type { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Product Product { get; set; }

        #endregion

        #region Constructors

        public Warehouse()
        { }

        public Warehouse(long sku, int quantity, string locality, WarehouseTypes type)
        {
            Sku = sku;
            Type = type;
            Quantity = quantity;
            Locality = locality;
        }

        #endregion

        #region Overriden Methods

        public override int GetHashCode()
            => base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            var other = (obj as Warehouse);

            return (Sku == other.Sku
                && Type == other.Type
                && Locality.Equals(other.Locality, StringComparison.OrdinalIgnoreCase)
            );
        }

        #endregion
    }
}
