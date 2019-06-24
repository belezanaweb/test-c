using BelezanaWeb.Infraestructure.Data.MongoDB.Database.Contracts;
using BelezanaWeb.Model.Configuration;

namespace BelezanaWeb.Infraestructure.Data.MongoDB.Database
{
    public class Configuration : IConfiguration
    {
        private string ServerMongo { get; set; }
        private string DbMongo { get; set; }
        private string DbCollection { get; set; }

        public Configuration()
        {
            // mongo 
            ServerMongo = AppSettings.MongoDB.ServerName;
            DbMongo = AppSettings.MongoDB.DatabaseName;
            DbCollection = AppSettings.MongoDB.Collection;
        }

        public string getServerMongo()
        {
            return ServerMongo;
        }

        public string getDbMongo()
        {
            return DbMongo;
        }

        public string getCollectionMongo()
        {
            return DbCollection;
        }
    }
}

