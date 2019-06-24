using BelezanaWeb.Infraestructure.Data.MongoDB.Database.Contracts;
using BelezanaWeb.Model.Domain;
using MongoDB.Driver;
using System;

namespace BelezanaWeb.Infraestructure.Data.MongoDB.Database
{
    public class MongoManager : IMongoManager
    {
        private readonly IConfiguration _Configuration;
        private IMongoDatabase configurationClient;


        public MongoManager(IConfiguration configuration)
        {
            _Configuration = configuration;
            Init();
        }

        public void Insert(LogModel log)
        {
            try
            {
                var collection = configurationClient.GetCollection<LogModel>(_Configuration.getCollectionMongo());
                collection.InsertOne(log);
            }
            catch (Exception ex)
            {
                // N�o subir exce��o.
            }
        }

        private IMongoDatabase GetDataBaseConfiguration()
        {
            try
            {
                if (configurationClient == null)
                {
                    var client = new MongoClient(_Configuration.getServerMongo());
                    this.configurationClient = client.GetDatabase(_Configuration.getDbMongo());
                }
            }
            catch (Exception ex)
            {
                // N�o subir exce��o.
            }

            return configurationClient;
        }

        private void Init()
        {
            GetDataBaseConfiguration();
        }
    }
}

