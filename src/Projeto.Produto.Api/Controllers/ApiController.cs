using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Interfaces;

namespace Projeto.Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public ApiController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        protected new IActionResult Response(object result = null)
        {
            if (_notificationService.HasNotification)
            {
                return BadRequest(new { errors = _notificationService.Notification });
            }

            return Ok(new { data = result });
        }

        protected IActionResult ResponseNotFound()
        {
            if (_notificationService.HasNotification)
            {
                return NotFound(new { errors = _notificationService.Notification });
            }

            return NotFound();
        }
    }
}
