using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produto.Domain.Models;
using Produto.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Infra.Mapping
{
    internal class ProductConfiguration : DbEntityConfiguration<Product>
    {

        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Produtos");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(p => p.Sku).IsRequired();
            entity.HasIndex(p => p.Sku)
                  .IsUnique(true);
            entity.Property(p => p.Name)
                .HasMaxLength(200);
            entity.HasOne(p => p.Invenctory)
                .WithOne(i => i.Product).HasForeignKey
                <Invenctory>(p => p.ProductId);
        }
    }
}
