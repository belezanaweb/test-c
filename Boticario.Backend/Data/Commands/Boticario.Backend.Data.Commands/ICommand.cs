using Boticario.Backend.Data.Connection;
using System.Threading.Tasks;

namespace Boticario.Backend.Data.Commands
{
    public interface ICommand<T>
    {
        Task<T> Execute(IConnection connection);
    }
}
