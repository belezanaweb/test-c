using Boticario.Backend.Data.Database;

namespace Boticario.Backend.Data.Connection
{
    public interface IConnection
    {
        IDatabase Database { get; }
    }
}
