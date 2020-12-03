using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingSection);

            var appSetting = appSettingSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(authJwt =>
            {
                authJwt.RequireHttpsMetadata = true;
                authJwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSetting.ValidIn,
                    ValidIssuer = appSetting.Emitter,
                    RequireExpirationTime = true
                };
            });
        }

        public static TokenModel GenerateJwtToken(AppSetting appSetting)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = appSetting.Emitter,
                Audience = appSetting.ValidIn,
                Expires = DateTime.UtcNow.AddMinutes(appSetting.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return new TokenModel
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
