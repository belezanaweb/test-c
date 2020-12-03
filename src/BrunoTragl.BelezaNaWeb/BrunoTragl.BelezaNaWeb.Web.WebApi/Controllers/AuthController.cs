using BrunoTragl.BelezaNaWeb.Web.WebApi.Configurations;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Enumerable;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AuthController : MainController
    {
        private readonly IConfiguration _configuration;
        private readonly AppSetting _appSetting;
        public AuthController(ILogger<MainController> mainLogger,
                              IConfiguration configuration,
                              IOptions<AppSetting> appSetting)
            : base(mainLogger)
        {
            _configuration = configuration;
            _appSetting = appSetting.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetToken(UserModel userModel)
        {
            try
            {
                if (UserSetting.ValidateUser(_configuration, userModel.User, userModel.Password))
                    return Ok(JwtConfiguration.GenerateJwtToken(_appSetting));

                return NotFound(new
                {
                    error = "Invalid username or password",
                    requested = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(Resources.Auth, ex);
            }
        }
    }
}
