using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BelezaNaWeb.Domain.Enums
{
    public abstract class Enum : IComparable
    {
        public string name { get; private set; }

        public int id { get; private set; }

        protected Enum(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString() => this.name;

        public static IEnumerable<T> getAll<T>() where T : Enum
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enum;

            if (otherValue == null)
                return false;

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.id.Equals(otherValue.id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => this.id.CompareTo(((Enum)other).id);

    }
}
