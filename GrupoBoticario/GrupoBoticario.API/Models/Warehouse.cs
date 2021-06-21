using System.ComponentModel.DataAnnotations;

namespace GrupoBoticario.API.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }        
        public int Sku { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
