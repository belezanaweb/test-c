using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBoticario.Domain.Entity.Base
{
    public class ObjectIdAutoGeneratorNumeric : ObjetoBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Sku { get; set; }        
    }
}
