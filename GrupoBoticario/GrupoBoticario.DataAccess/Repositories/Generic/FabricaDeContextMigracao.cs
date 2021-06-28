using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GrupoBoticario.DataAccess.Repositories.Generic
{
    public class FabricaDeContextMigracao : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {            
            var optionBuilder = new DbContextOptionsBuilder<Context>();            
            string strCon = $"Data Source=C:\\bw\\bw.db";
            optionBuilder.UseSqlite(strCon);
            return new Context(optionBuilder.Options);
        }
    }
}
