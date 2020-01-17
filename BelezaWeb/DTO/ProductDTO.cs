namespace DTO
{
    /// <summary>
    /// DTO for Product
    /// </summary>
    public class ProductDTO
    {
        #region Properties        

        /// <summary>
        /// Sku Product
        /// </summary>
        public int Sku { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Inventory of the product
        /// </summary>
        public InventoryDTO Inventory { get; set; }

        /// <summary>
        /// Is marketable or not 
        /// </summary>
        public bool IsMarketable => Inventory.Quantity > 0;

        #endregion      
    }
}
