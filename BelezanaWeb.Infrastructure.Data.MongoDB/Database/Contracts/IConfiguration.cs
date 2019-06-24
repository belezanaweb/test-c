namespace BelezanaWeb.Infraestructure.Data.MongoDB.Database.Contracts
{
    public interface IConfiguration
    {
        string getServerMongo();
        string getDbMongo();
        string getCollectionMongo();
    }
}

