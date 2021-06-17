using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.Interfaces.Application
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}
