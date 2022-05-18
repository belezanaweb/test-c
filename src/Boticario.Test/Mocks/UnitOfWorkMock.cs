using Boticario.Core.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Tests.Mocks
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        public Task<bool> Comitar()
        {
            return Task.FromResult(true);
        }
    }
}
