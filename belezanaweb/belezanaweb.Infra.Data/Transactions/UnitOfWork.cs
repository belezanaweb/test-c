using belezanaweb.Infra.Data.Context;

namespace belezanaweb.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BelezanawebContext _context;

        public UnitOfWork(BelezanawebContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //data still in memory
        }
    }
}
