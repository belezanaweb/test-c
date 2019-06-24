using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BelezanaWeb.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        //private HttpResponseMessage responseMessage;
        private ObjectResult responseMessage;

        public BaseController()
        {
            //this.responseMessage = new ObjectResult();
        }

        /// <summary>
        /// Retorna response de sucesso com status code 200. Utilizado para métodos GET.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseOk(object content)
        {
            responseMessage = StatusCode((int)HttpStatusCode.OK, content);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseNotFound()
        {
            responseMessage = StatusCode((int)HttpStatusCode.NotFound, "NotFound");
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseNotFound(string message)
        {
            responseMessage = StatusCode((int)HttpStatusCode.NotFound, message);
            return Task.FromResult(responseMessage);
        }

        /// <summary>
        /// Retorna response de sucesso com status code 202.
        /// Utilizado para métodos com processamento ainda não foi concluído
        /// (utilizado em requisições assincronas).
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseAccepted(object content)
        {
            responseMessage = StatusCode((int)HttpStatusCode.Accepted, content);
            return Task.FromResult(responseMessage);
        }

        /// <summary>
        /// Retorna response de sucesso com status code 201. Utilizado para método POST.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseCreated(string message = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.Created, message);
            return Task.FromResult(responseMessage);
        }

        /// <summary>
        /// Retorna response de sucesso com status code 204. Utilizado para método PUT.
        /// </summary>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseNoContent()
        {
            responseMessage = StatusCode((int)HttpStatusCode.NoContent, null);
            return Task.FromResult(responseMessage);
        }

        /// <summary>
        /// Retorna response de falha com status code 500. 
        /// Utilizado em caso de erros inesperados na implementação.
        /// </summary>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseInternalServerError(string message = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.InternalServerError, message);
            return Task.FromResult(responseMessage);
        }

        /// <summary>
        /// Retorna response de falha com status code 400.
        /// Utilizado em caso de erro com os dados do request.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected Task<ObjectResult> ResponseBadRequest()
        {
            responseMessage = StatusCode((int)HttpStatusCode.BadRequest, null);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseBadRequest(string message)
        {
            responseMessage = StatusCode((int)HttpStatusCode.BadRequest, message);
            return Task.FromResult(responseMessage);
        }     
    }
}
