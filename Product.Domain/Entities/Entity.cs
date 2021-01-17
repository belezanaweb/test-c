using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }

    }
}
