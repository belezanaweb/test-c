using Desafio.Infra.Data.Interfaces;
using System.Data.SQLite;

namespace Desafio.Infra.Data.Repository
{
    public abstract class Repository
    {
        private readonly IMainContext _appContext;

        public Repository(IMainContext appContext)
        {
            _appContext = appContext;
        }

        public SQLiteConnection Connection 
        {
            get => _appContext.Connection; 
        }

    }
}
