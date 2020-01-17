namespace DTO
{
    /// <summary>
    /// DTO for Warehouse products
    /// </summary>
    public class WarehouseDTO
    {
        #region Properties             

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

        #endregion
    }
}
