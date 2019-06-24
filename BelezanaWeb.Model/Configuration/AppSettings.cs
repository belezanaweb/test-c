namespace BelezanaWeb.Model.Configuration
{
    public static class AppSettings
    {
        public static void Initialize()
        {
            ConnectionString = new ConnectionString();
            TokenConfiguration = new TokenConfiguration();
            Redis = new Redis();
            MongoDB = new MongoDBConfiguration();
        }

        public static ConnectionString ConnectionString;
        public static TokenConfiguration TokenConfiguration;
        public static Redis Redis;
        public static MongoDBConfiguration MongoDB;
    }

    public class ConnectionString
    {
        public string BelezanaWebDatabase { get; set; }
    }

    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public long Seconds { get; set; }

    }

    public class Redis
    {
        public string Server { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }

    public class MongoDBConfiguration
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Collection { get; set; }
    }
}