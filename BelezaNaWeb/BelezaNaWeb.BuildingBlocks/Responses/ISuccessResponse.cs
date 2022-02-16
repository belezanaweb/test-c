namespace BelezaNaWeb.BuildingBlocks.Responses
{
    public interface ISuccessResponse<T>
    {
        public T Data { get; }
    }
}
