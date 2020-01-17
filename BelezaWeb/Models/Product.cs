using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Model for Product
    /// </summary>
    public class Product
    {
        #region Properties

        /// <summary>
        /// Id
        /// </summary>
        [Column("Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Sku Product
        /// </summary>
        public int Sku { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of Warehouses
        /// </summary>
        public IList<Warehouse> Warehouses { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Product()
        {
            Warehouses = new List<Warehouse>();
        }

        #endregion
    }
}
