namespace belezanaweb.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
