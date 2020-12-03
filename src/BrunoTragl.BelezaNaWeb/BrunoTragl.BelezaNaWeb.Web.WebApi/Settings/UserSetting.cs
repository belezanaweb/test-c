using Microsoft.Extensions.Configuration;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Settings
{
    public class UserSetting
    {
        public UserSetting(IConfiguration configuration)
        {
            var userSettingSection = configuration.GetSection("UserSetting");
            var userSetting = userSettingSection.GetSection("User");
            var passwordSetting = userSettingSection.GetSection("Password");
            User = userSetting.Value;
            Password = passwordSetting.Value;
        }

        public string User { get; }
        public string Password { get; }

        public static bool ValidateUser(IConfiguration configuration, string user, string password)
        {
            var userSetting = new UserSetting(configuration);
            return userSetting.User == user && userSetting.Password == password;
        }
    }
}
