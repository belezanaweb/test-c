using BoticarioAPI.Domain.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Application.Application
{
    public class AppBase
    {
        private readonly IUnitOfWork _uow;

        public AppBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected bool Save()
        {
            return _uow.Commit();
        }
    }
}
