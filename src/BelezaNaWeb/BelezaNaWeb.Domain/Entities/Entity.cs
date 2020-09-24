using System;
using System.Runtime.Serialization;
using BelezaNaWeb.Domain.Interfaces.Entities;

namespace BelezaNaWeb.Domain.Entities
{
    [Serializable]
    [DataContract]
    public abstract class Entity : IEntity
    {
        #region Public Properties

        #endregion

        #region IEntity Members

        public object Clone()
            => MemberwiseClone();

        #endregion
    }
}
