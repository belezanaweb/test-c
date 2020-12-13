using Dapper;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Models;
using Desafio.Infra.Data.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IMainContext appContext) 
            : base(appContext)
        {
        }

        public void Create(Product product)
        {
            var sql = new StringBuilder()
                .AppendLine("insert into Product")
                .AppendLine("(Sku, Name)")
                .AppendLine("values")
                .AppendLine("(@Sku, @Name)");

            Connection.Execute(sql.ToString(), product);
        }

        public bool Exists(int sku)
        {
            var sql = new StringBuilder()
                .AppendLine("select")
                .AppendLine("count(1)")
                .AppendLine("from Product")
                .AppendLine("where Sku = @sku");

            return Connection.ExecuteScalar<bool>(sql.ToString(), new { sku });
        }

        public Product Read(int sku)
        {
            var sql = new StringBuilder()
                .AppendLine("select")
                .AppendLine("Sku,")
                .AppendLine("Name")
                .AppendLine("from Product")
                .AppendLine("where Sku = @sku");

            return Connection.Query<Product>(sql.ToString(), new { sku }).FirstOrDefault();
        }

        public void Update(Product product)
        {
            var sql = new StringBuilder()
                .AppendLine("update Product set")
                .AppendLine("Name = @Name")
                .AppendLine("where Sku = @Sku");

            Connection.Execute(sql.ToString(), product);
        }

        public void Delete(int sku)
        {
            var sql = new StringBuilder()
                .AppendLine("delete from Product")
                .AppendLine("where Sku = @sku");

            Connection.Execute(sql.ToString(), new { Sku = sku });
        }
    }
}
