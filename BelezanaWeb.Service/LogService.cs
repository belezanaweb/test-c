using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Interface.Service;
using BelezanaWeb.Model;
using BelezanaWeb.Model.Domain;
using BelezanaWeb.Model.Enums;
using BelezanaWeb.Model.Extensions;
using System;

namespace BelezanaWeb.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository LogRepository)
        {
            logRepository = LogRepository;
        }

        public void Insert(LogModel log)
        {
            logRepository.Insert(log);
        }

        public void Insert(Exception exp, string step = null)
        {
            try
            {
                var log = new LogModel();

                log.Message = exp.Message;
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.Status = LogType.Exception.ToString();
                log.Step = step;
                log.Error = exp.GetInnerMessages();

                logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(string message, string step = null)
        {
            try
            {
                var log = new LogModel();

                log.Message = message;
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.Status = LogType.Iteration.ToString();
                log.Step = step;

                logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(ResultBase result, string message)
        {
            Insert(result, message, null);
        }

        public void Insert(ResultBase result, LogType logType)
        {
            Insert(result, logType, null, null);
        }

        public void Insert(ResultBase result, LogType logType, string message)
        {
            Insert(result, logType, message, null);
        }

        public void Insert(ResultBase result, LogType logType, string message, string step)
        {
            try
            {
                var log = new LogModel();

                log.Step = step;
                log.Message = message ?? result.FriendlyMessage;
                log.FriendlyMessage = result.FriendlyMessage;
                log.Object = log.Object;
                log.Status = logType.ToString();
                log.Request = result.Request;
                log.Response = result.Response;
                log.Error = result.Error == null ? null : result.Error.GetInnerMessages();
                log.Created = DateTimeExtensions.GetBrazilianDate();

                logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(ResultBase result, string message, string step)
        {
            try
            {
                var log = new LogModel();

                log.Step = step;
                log.Message = message ?? result.FriendlyMessage;
                log.FriendlyMessage = result.FriendlyMessage;
                log.Object = log.Object;
                log.Status = result.Error == null ? "Iteration" : "Exception";
                log.Request = result.Request;
                log.Response = result.Response;
                log.Error = result.Error == null ? null : result.Error.GetInnerMessages();
                log.Created = DateTimeExtensions.GetBrazilianDate();

                logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }


        public void Insert(Object obj, string message)
        {
            Insert(obj, message, null);
        }

        public void Insert(Object obj, string message, string step)
        {
            try
            {
                var log = new LogModel();

                log.Status = "Iteration";
                log.Step = step;
                log.Object = obj;
                log.Message = message;
                log.Created = DateTimeExtensions.GetBrazilianDate();

                logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }
    }
}
