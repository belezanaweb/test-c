using Boticario.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Boticario.Api.Controllers
{

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly ILogger _logger;


        public MainController(ILogger logger, INotification notification)
        {
            _notification = notification;
            _logger = logger;
        }

     

        protected IActionResult Result(object result, string message = null)
        {
            var errosValidation = _notification?.GetErrors().Select(x => x.Message).ToList();

            bool ocorreuErro = _notification.HasErrors();

            
            //Caso ocorra um erro
            if (ocorreuErro && _logger != null && errosValidation.Count > 0)
            {
                string mensErro = string.Join(",", errosValidation);

                //Joga no log
                _logger.LogError(mensErro);
            }


            if (ocorreuErro)
                return BadRequest(errosValidation);


            else
            {
                var response = result != null ? result : message;

                string method =  Request.Method.ToString().ToUpper();

                if (method == HttpMethod.Put.ToString().ToUpper() || method == HttpMethod.Patch.ToString().ToUpper() || method == HttpMethod.Get.ToString().ToUpper())
                    return Ok(response);

                else if (method == HttpMethod.Put.ToString().ToUpper())
                    return Created("", response);

                else if (method == HttpMethod.Delete.ToString().ToUpper())
                    return NoContent();

                else
                    return Ok(response);
            }



        }

        


    }
}
