using BelezaNaWeb.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Tests
{
    public class UnitTestDbContext : BelezaNaWebContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("BelezaNaWebUnitTests");
        }
    }
}
