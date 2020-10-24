using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection
{
    public interface IConnectionFactory
    {
        Task<IConnection> Create();
    }
}
