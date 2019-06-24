using BelezanaWeb.Infraestructure.Data.MongoDB.Database.Contracts;
using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Model.Domain;

namespace BelezanaWeb.Infraestructure.Data.MongoDB.Repository
{
    public class LogRepository : ILogRepository
    {
        private IMongoManager _MongoManager;

        public LogRepository(IMongoManager MongoManager)
        {
            _MongoManager = MongoManager;
        }

        public void Insert(LogModel log)
        {
            _MongoManager.Insert(log);
        }
    }
}

