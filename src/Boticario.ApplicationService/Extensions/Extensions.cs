namespace Boticario.ApplicationService
{
    public static class Extensions
    {

        public static string ToJson(this object pPoject)
        {
            return System.Text.Json.JsonSerializer.Serialize(pPoject);
        }

    }
}
