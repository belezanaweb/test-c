using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.Database;
using System;

namespace Boticario.Backend.Data.UnitOfWork.Tests.Mocks
{
    internal class ConnectionMock : IConnection
    {
        public IDatabase Database => throw new NotImplementedException();
    }
}
