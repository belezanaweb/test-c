namespace Boticario.Backend.Data.Connection
{
    public interface IConnectionFactory
    {
        IConnection Create();
    }
}
