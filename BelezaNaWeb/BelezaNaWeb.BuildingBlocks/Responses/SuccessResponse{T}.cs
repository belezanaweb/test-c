namespace BelezaNaWeb.BuildingBlocks.Responses
{
    public class SuccessResponse<T> : ISuccessResponse<T>
    {
        public SuccessResponse(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
