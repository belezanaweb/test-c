using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produto.Domain.Models;
using Produto.Infra.Extensions;

namespace Produto.Infra.Mapping
{
    internal class WareHouseConfiguration : DbEntityConfiguration<WareHouse>
    {
        public override void Configure(EntityTypeBuilder<WareHouse> entity)
        {
            entity.ToTable("WareHouses");
            entity.HasKey(w => w.Id);
            entity.HasOne(w => w.Invenctory)
                  .WithMany(w => w.WareHouses);
        }
    }
}
