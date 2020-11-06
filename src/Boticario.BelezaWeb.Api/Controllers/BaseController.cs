using Microsoft.AspNetCore.Mvc;

namespace Boticario.BelezaWeb.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		protected static IActionResult Json(object result)
		{
			return new JsonResult(result);
		}

		protected static IActionResult Json(bool success, object result)
		{
			return new JsonResult(new { success, result });
		}
	}
}
