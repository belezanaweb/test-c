using System;

namespace Belezanaweb.Domain.Core.Entities
{
    public class EntityBase : IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
