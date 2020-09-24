using System;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Api.Infrastructure.Config
{
    [DataContract]
    [Serializable]
    public sealed class SwaggerConfig
    {
        #region Public Properties

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string Description { get; set; }

        #endregion
    }
}
