using System;

#nullable enable

namespace BelezaNaWeb.Domain.Exceptions
{
    public sealed class ApiException : Exception
    {
        #region Public Properties

        public int Code { get; }
        public string Name { get; }

        #endregion

        #region Constructors

        public ApiException(string name, string message, int code)
            : this(name, message, code, null)
        { }

        public ApiException(string name, string message, int code, Exception? innerException)
            : base(message, innerException)
        {
            Name = name;
            Code = code;
        }

        #endregion
    }
}
