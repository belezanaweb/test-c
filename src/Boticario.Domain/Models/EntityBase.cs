using System;

namespace Boticario.Domain.Models
{
    public abstract class EntityBase
    {
        public EntityBase(Guid id = new Guid())
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }
        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
    }
}
