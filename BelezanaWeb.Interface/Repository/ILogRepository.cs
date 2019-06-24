using BelezanaWeb.Model.Domain;

namespace BelezanaWeb.Interface.Repository
{
    public interface ILogRepository
    {
        void Insert(LogModel log);
    }
}
