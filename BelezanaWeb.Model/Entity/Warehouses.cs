using System;

namespace BelezanaWeb.Model
{
    /// <summary>
    /// Warehouse entity.
    /// </summary>
    [Serializable]
    public class Warehouse : BaseEntity
    {    
        public long ProductId { get; set; }
        public string Locality  { get; set; }
        public int Quantity  { get; set; }
        public string Type  { get; set; }

        public long ProductRefId { get; set; }
        public Product Product { get; set; }
    }
}

