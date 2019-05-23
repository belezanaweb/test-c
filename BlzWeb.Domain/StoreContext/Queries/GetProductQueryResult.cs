namespace BlzWeb.Domain.StoreContext.Queries
{
    public sealed class GetProductQueryResult
    {
        public int Sku { get; private set; }
        public string Name { get; private set; }
        public bool IsMarketable { get; private set; }
    }
}
