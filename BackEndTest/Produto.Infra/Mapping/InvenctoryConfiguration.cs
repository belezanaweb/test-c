using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produto.Domain.Models;
using Produto.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Infra.Mapping
{
    internal class InvenctoryConfiguration : DbEntityConfiguration<Invenctory>
    {
        public override void Configure(EntityTypeBuilder<Invenctory> entity)
        {
            entity.ToTable("Inventarios");
            entity.HasKey(i => i.Id);
            entity.Property(i => i.ProductId).IsRequired();
            entity.HasOne(i => i.Product)
               .WithOne(p => p.Invenctory).HasForeignKey
               <Invenctory>(i => i.ProductId);
            entity.HasMany(i => i.WareHouses)
                .WithOne(w => w.Invenctory);
        }
    }
}
