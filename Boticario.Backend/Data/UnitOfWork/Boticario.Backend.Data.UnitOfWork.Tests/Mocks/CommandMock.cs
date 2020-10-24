using Boticario.Backend.Data.Commands;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.UnitOfWork.Tests.Mocks
{
    internal class CommandMock : IWriterCommand
    {
        public bool Executed { get; private set; }

        public async Task<bool> Execute()
        {
            return await Task.Run(() =>
            {
                this.Executed = true;
                return true;
            });
        }
    }
}
