using System;
using System.Data.SqlClient;

namespace BlzWeb.Infra.DataContexts
{
    public class BlzWebDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BlzWebDataContext()
        {
            //Connection = new SqlConnection(Settings.ConnectionString);
            //Connection.Open();
        }

        public void Dispose()
        {
            //if (Connection.State != ConnectionState.Closed)
            //    Connection.Close();
        }
    }
}