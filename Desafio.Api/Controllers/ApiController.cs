using Desafio.Domain.Command;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(CommandResult commandResult = null)
        {
            switch (commandResult.Status)
            {
                case CommandResultStatus.Ok:
                    return Ok(new { success = true, message = ""});
                case CommandResultStatus.Warning:
                    return Ok(new { success = false, message = commandResult.Message });
                case CommandResultStatus.Error:
                    return BadRequest(new { message = commandResult.Message });
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
