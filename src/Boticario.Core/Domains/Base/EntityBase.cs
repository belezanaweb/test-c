using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Domains.Base
{
    public class EntityBase
    {
        public int Id { get; set; }

        public bool IDValido => Id > 0;
    }
}
