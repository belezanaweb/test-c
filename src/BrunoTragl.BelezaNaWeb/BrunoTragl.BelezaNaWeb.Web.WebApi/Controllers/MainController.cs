using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Enumerable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        protected MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        protected IActionResult OkResult(Resources resource, object data = null)
        {
            try
            {
                object obj = new {
                    data,
                    requested = DateTime.UtcNow
                };

                _logger.LogInformation($"resource requested of {resource.ToString()}", obj);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(resource, ex);
            }
        }
        protected IActionResult CreatedResult(Resources resource, string uri, object data = null)
        {
            try
            {
                object obj = new
                {
                    data,
                    requested = DateTime.UtcNow
                };

                _logger.LogInformation($"{resource.ToString()} resource created", obj);

                return Created(uri, obj);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(resource, ex);
            }
        }
        protected IActionResult BadRequestResult(Resources resource, object errors = null, object request = null)
        {
            try
            {
                _logger.LogInformation($"{resource} resource get a bad request", new
                {
                    request,
                    errors
                });

                return BadRequest(new
                {
                    errors,
                    requested = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(resource, ex);
            }
        }
        protected IActionResult InternalServerErrorResponse(Resources resource, Exception ex)
        {
            try
            {
                _logger.LogError($"{resource.ToString()} resource delivery error", GetMessageErrors(ex));
                return StatusCode(500, new
                {
                    errors = GetMessageErrors(ex),
                    requested = DateTime.UtcNow
                });
            }
            catch
            {
                return StatusCode(500, "An error occurred during the requested resource process");
            }
        }
        protected IEnumerable<string> GetModelStateErrors(ModelStateDictionary modelState)
        {
            return ModelState.Values.SelectMany(ms => ms.Errors.Select(e => e.ErrorMessage));
        }
        private IList<string> GetMessageErrors(Exception ex)
        {
            List<string> messageErrors = new List<string>();

            if (ex != null && string.IsNullOrEmpty(ex.Message))
                messageErrors.Add(ex.Message);

            if (ex?.InnerException != null && string.IsNullOrEmpty(ex?.InnerException.Message))
                messageErrors.Add(ex.InnerException.Message);

            return messageErrors;
        }
    }
}
