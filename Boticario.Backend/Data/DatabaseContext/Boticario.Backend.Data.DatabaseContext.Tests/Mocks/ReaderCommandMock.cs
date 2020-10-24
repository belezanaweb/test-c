using Boticario.Backend.Data.Commands;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext.Tests.Mocks
{
    internal class ReaderCommandMock : IReaderCommand<string>
    {
        private readonly string desiredResult;

        public ReaderCommandMock(string desiredResult)
        {
            this.desiredResult = desiredResult;
        }

        public async Task<string> Execute()
        {
            return await Task.Run(() =>
            {
                return this.desiredResult;
            });
        }
    }
}
