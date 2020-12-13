using Dapper;
using Desafio.Infra.Data.Interfaces;
using System.Data.SQLite;
using System.Text;

namespace Desafio.Infra.Data.Context
{
    public class MainContext : IMainContext
    {
        public MainContext()
        {
            Connection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
            Connection.Open();
            createTables();
        }

        public SQLiteConnection Connection { get; private set; }

        public void Dispose()
        {
            Connection.Dispose();
        }

        private void createTables()
        {
            var sql = @"
                CREATE TABLE Product (
                    Sku   INTEGER NOT NULL,
	                Name  TEXT NOT NULL,
	                PRIMARY KEY(Sku)
                );

                CREATE TABLE Warehouse (

                    Sku   INTEGER NOT NULL,
	                Locality  TEXT NOT NULL,
	                Quantity  INTEGER NOT NULL,
	                Type  TEXT NOT NULL,
	                FOREIGN KEY(Sku) REFERENCES Product(Sku) ON DELETE CASCADE
                )
            ";

            Connection.Execute(sql);
        }
    }
}
