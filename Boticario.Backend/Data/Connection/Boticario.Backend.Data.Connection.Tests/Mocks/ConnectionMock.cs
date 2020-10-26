using Boticario.Backend.Data.Database;

namespace Boticario.Backend.Data.Connection.Tests.Mocks
{
    internal class ConnectionMock : IConnection
    {
        public IDatabase Database => throw new System.NotImplementedException();
    }
}
