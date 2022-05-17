namespace webapi.application.UseCases
{
    public interface IUseCase<TRequest>
    {
         Task Execute(TRequest request);
    }
    public interface IUseCase<TRequest, TResponse>
    {
         Task<TResponse> Execute(TRequest request);
    }
}