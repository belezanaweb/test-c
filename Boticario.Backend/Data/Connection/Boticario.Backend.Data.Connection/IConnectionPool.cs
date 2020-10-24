using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection
{
    public interface IConnectionPool
    {
        Task<IConnection> Pop();
        void Push(IConnection connection);
    }
}
