using System;
using System.Collections.Generic;

namespace BelezaNaWeb.Api.Extensions
{
    public static class ExceptionExtensions
    {
        #region Extension Methods

        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }

        #endregion
    }
}
