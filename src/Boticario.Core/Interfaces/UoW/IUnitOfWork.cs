using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> Comitar();
    }
}
