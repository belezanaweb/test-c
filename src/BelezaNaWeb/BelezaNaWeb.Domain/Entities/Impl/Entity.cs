using System;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities.Impl
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
