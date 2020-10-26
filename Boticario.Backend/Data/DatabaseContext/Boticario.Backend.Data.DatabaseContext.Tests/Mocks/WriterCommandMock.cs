using Boticario.Backend.Data.Commands;
using Boticario.Backend.Data.Connection;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests.Mocks
{
    internal class WriterCommandMock : IWriterCommand
    {
        public bool Executed { get; private set; }

        public async Task<bool> Execute(IConnection connection)
        {
            return await Task.Run(() =>
            {
                this.Executed = true;
                return true;
            });
        }
    }
}
