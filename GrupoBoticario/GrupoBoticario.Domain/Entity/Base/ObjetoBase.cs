using System;

namespace GrupoBoticario.Domain.Entity.Base
{
    public class ObjetoBase
    {
        public DateTime? _CreateAt;
        public DateTime? CreateAt
        {
            get { return _CreateAt; }
            set { _CreateAt = (value == null) ? DateTime.UtcNow : value; }
        }
        public DateTime? UpdateAt { get; set; }

        public long IdkeyReference { get; set; }
    }
}
