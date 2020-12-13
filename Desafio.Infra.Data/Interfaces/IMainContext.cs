using System;
using System.Data.SQLite;

namespace Desafio.Infra.Data.Interfaces
{
    public interface IMainContext : IDisposable
    {
        SQLiteConnection Connection { get; }
    }
}