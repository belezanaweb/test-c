using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Model for Warehouse products
    /// </summary>
    public class Warehouse
    {
        #region Properties

        /// <summary>
        /// Id
        /// </summary>
        [Column("Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id of the project
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product locality
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Type of the product
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
