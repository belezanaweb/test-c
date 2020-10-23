using Boticario.Backend.Data.Commands;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.DatabaseContext
{
    public interface IDatabaseContext
    {
        Task<T> ExecuteCommand<T>(ICommand<T> command);
    }
}
