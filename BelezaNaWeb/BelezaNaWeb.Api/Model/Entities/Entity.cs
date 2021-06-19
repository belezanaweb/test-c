using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Model.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sku { get; set; }   
    }
}