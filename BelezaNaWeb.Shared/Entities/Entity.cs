using System;

namespace BelezaNaWeb.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; private set; }
    }
}
