using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity;

            return Id == compareTo.Id;
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
