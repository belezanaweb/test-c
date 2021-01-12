using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBoticarioTeste.Business.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public int ProductId { get; set; }        
        public Product Product { get; set; }
    }
}
