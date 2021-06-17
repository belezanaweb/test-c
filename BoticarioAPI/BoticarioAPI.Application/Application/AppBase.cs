using BoticarioAPI.Domain.Interfaces.Application;

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
