using BoticarioAPI.Domain.Interfaces.Application;
using System;

namespace BoticarioAPI.Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoticarioContext _context;
        public UnitOfWork(BoticarioContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
