using System;
using System.Runtime.Serialization;
namespace testc.Model.Base

{
    [DataContract]
    public class BaseEntity
    {
        public long? Sku { get; set; }
    }
}
