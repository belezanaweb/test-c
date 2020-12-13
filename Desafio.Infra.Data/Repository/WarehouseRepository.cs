using Dapper;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Models;
using Desafio.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Infra.Data.Repository
{
    public class WarehouseRepository : Repository, IWarehouseRepository
    {
        public WarehouseRepository(IMainContext appContext) 
            : base(appContext)
        {
        }

        public void Create(Warehouse warehouse)
        {
            var sql = new StringBuilder()
                .AppendLine("insert into Warehouse")
                .AppendLine("(Sku, Locality, Quantity, Type)")
                .AppendLine("values")
                .AppendLine("(@Sku, @Locality, @Quantity, @Type)");

            Connection.Execute(sql.ToString(), warehouse);
        }

        public List<Warehouse> Read(int sku)
        {
            var sql = new StringBuilder()
                .AppendLine("select")
                .AppendLine("Sku,")
                .AppendLine("Locality,")
                .AppendLine("Quantity,")
                .AppendLine("Type")
                .AppendLine("from Warehouse")
                .AppendLine("where Sku = @sku");

            return Connection.Query<Warehouse>(sql.ToString(), new { sku }).ToList();
        }

        public void Delete(int sku)
        {
            var sql = new StringBuilder()
                .AppendLine("delete from Warehouse")
                .AppendLine("where Sku = @sku");

            Connection.Execute(sql.ToString(), new { sku });
        }
    }
}
