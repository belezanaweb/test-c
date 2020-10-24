using Boticario.Backend.Data.Commands;
using System;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Implementation
{
    public class DatabaseContextImpl : IDatabaseContext
    {
        public Task<T> ExecuteCommand<T>(ICommand<T> command)
        {
            throw new NotImplementedException();
        }
    }
}
