using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrupoBoticario.Domain.Entity.Base
{
    public class ObjectIdNoneGeneratorNumeric : ObjetoBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Sku { get; set; }
    }
}
