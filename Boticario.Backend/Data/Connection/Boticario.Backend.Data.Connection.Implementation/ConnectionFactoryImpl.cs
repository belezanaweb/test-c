namespace Boticario.Backend.Data.Connection.Implementation
{
    public class ConnectionFactoryImpl : IConnectionFactory
    {
        public IConnection Create()
        {
            return new ConnectionImpl();
        }
    }
}
