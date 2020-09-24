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
        public string Sku { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public WarehouseTypes Locality { get; set; }

        #endregion
    }
}
