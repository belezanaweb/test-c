namespace BoticarioAPI.Domain.Interfaces.Application
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}
