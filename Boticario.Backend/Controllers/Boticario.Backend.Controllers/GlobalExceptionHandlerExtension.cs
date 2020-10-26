using Boticario.Backend.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;

namespace Boticario.Backend.Controllers
{
    public static class GlobalExceptionHandlerExtension
    {
		private static HttpStatusCode VerifyStatusCode(Exception exception)
		{
			if (exception is IBusinessException)
			{
				return HttpStatusCode.BadRequest;
			}

			if (exception is IObjectNotFoundException)
			{
				return HttpStatusCode.NotFound;
			}

			return HttpStatusCode.InternalServerError;
		}

		public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (exceptionHandlerFeature != null)
					{
						context.Response.ContentType = "application/json";
						context.Response.StatusCode = (int)VerifyStatusCode(exceptionHandlerFeature.Error);

						var json = new
						{
							context.Response.StatusCode,
							exceptionHandlerFeature.Error.Message
						};

						await context.Response.WriteAsync(JsonSerializer.Serialize(json));
					}
				});
			});
		}
	}
}
