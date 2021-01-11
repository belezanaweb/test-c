using System.ComponentModel.DataAnnotations;

namespace BNWTC.Api.ViewModel
{
    public class WarehouseViewModel
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int Sku { get; set; }

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
