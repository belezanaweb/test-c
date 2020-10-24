using Boticario.Backend.Data.Commands;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext
{
    public interface IDatabaseContext
    {
        Task<T> ExecuteReader<T>(IReaderCommand<T> command);
        Task ExecuteWriter(IWriterCommand command);
    }
}
