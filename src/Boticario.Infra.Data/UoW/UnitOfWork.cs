using Boticario.Core.Interfaces.UoW;
using Boticario.Data.Context;
using System;
using System.Threading.Tasks;

namespace Boticario.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _contexto;

        public UnitOfWork(DefaultContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Comitar()
        {
            using var contextTransaction = _contexto.Database.BeginTransaction();

            try
            {
                int affectedRows = 0;

                affectedRows += await _contexto.SaveChangesAsync();

                contextTransaction.Commit();

                return affectedRows > 0;
            }
            catch (Exception)
            {
                contextTransaction.Rollback();

                throw;
            }
        }
    }
}