namespace BelezaNaWeb.Infrastructure
{
    public class ProductConfiguration : IDbConfiguration
    {
        public string ConnectionString { get; set; }

        public string Schema { get; set; }
    }

    public interface IDbConfiguration
    {
        public string ConnectionString { get; }

        public string Schema { get; }
    }
}
