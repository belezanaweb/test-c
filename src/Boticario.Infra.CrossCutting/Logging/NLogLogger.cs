using Boticario.Domain.Interfaces;
using System;

namespace Boticario.Infra.CrossCutting.Logging
{
    public class NLogLogger : ILogger
    {
        #region Attributes

        private readonly NLog.Logger _appExLogger;

        #endregion

        #region Constructors

        public NLogLogger()
        {
            _appExLogger = NLog.LogManager.GetLogger("AppExceptionLog");
        }

        #endregion

        #region Public Methods

        public void LogException(Exception ex)
        {
            _appExLogger.Error(ex);
        }

        public void LogException(Exception ex, string message)
        {
            _appExLogger.Error(ex, message);
        }

        #endregion
    }
}