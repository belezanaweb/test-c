using Boticario.Backend.Data.Database;

namespace Boticario.Backend.Data.Connection.Implementation
{
    internal class DefaultConnection : IConnection
    {
        public IDatabase Database { get; private set; }

        public DefaultConnection(IDatabase database)
        {
            this.Database = database;
        }        
    }
}
