using Boticario.Backend.Data.Commands;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Connection
{
    public interface IConnection
    {
        Task<T> Execute<T>(ICommand<T> command);
    }
}
