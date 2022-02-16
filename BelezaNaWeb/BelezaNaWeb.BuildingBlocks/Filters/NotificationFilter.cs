using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.BuildingBlocks.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelezaNaWeb.BuildingBlocks.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (next is null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            return OnResultExecutionAsyncInternal(context, next);
        }

        private async Task OnResultExecutionAsyncInternal(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                var response = MapNotificationToResponse(_notificationContext.Notifications, context.HttpContext.TraceIdentifier);
                var responseJson = JsonSerializer.Serialize(response, _jsonOptions);

                if(_notificationContext.ErrorCode > 0)
                    context.HttpContext.Response.StatusCode = _notificationContext.ErrorCode;
                else
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                await context.HttpContext.Response.WriteAsync(responseJson);
                return;
            }

            await next();
        }

        private ErrorResponse MapNotificationToResponse(IReadOnlyCollection<Notification> notifications, string traceId)
        {
            var result = new ErrorResponse
            {
                Type = "BadRequest",
                Messsage = "Invalid request. See 'errors' for more details.",
                TraceId = traceId,
            };

            foreach (var notification in notifications)
            {
                result.AddError(new ErrorResponseItem
                {
                    Context = notification.Context,
                    Rule = notification.Rule,
                    Message = notification.Message,
                });
            }

            return result;
        }
    }
}
