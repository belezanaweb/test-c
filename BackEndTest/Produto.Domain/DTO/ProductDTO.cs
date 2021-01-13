using System.Text.Json;


namespace Produto.Domain.DTO
{
    public class ProductDTO
    {
       
        public string Sku { get; set; }
        public string Name { get; set; }
        public InvenctoryDTO Invenctory { get; set; }

    
    }

}
