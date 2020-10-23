namespace Boticario.Backend.Data.Connection.Tests.Mocks
{
    internal class ConnectionFactoryMock : IConnectionFactory
    {
        public IConnection Create()
        {
            return new ConnectionMock();
        }
    }
}
