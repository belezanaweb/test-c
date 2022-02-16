namespace BelezaNaWeb.BuildingBlocks.Responses
{
    public class SuccessResponse
    {
        public static SuccessResponse<T> Create<T>(T data)
        {
            return new SuccessResponse<T>(data);
        }
    }
}
