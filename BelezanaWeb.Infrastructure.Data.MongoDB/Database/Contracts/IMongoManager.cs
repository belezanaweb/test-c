using BelezanaWeb.Model.Domain;

namespace BelezanaWeb.Infraestructure.Data.MongoDB.Database.Contracts
{
    public interface IMongoManager
    {
        void Insert(LogModel log);
    }
}

