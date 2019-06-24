using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelezanaWeb.Model
{
    /// <summary>
    /// Product entity.
    /// </summary>
    [Serializable]
    public class Product : BaseEntity
    {       	
        public long Sku  { get; set; }
        public string Name  { get; set; }

        [ForeignKey("ProductRefId")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}

