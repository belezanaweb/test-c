using System;

namespace BelezanaWeb.Model.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetBrazilianDate()
        {
            var brazilDateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, GetBrazilTimeZone());
            return brazilDateTimeNow;
        }

        private static TimeZoneInfo GetBrazilTimeZone()
        {
            String timeZoneId = "E. South America Standard Time";
            TimeZoneInfo brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return brazilTimeZone;
        }
    }
}
