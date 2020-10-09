using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BelezaNaWebApplication.Persistence.EntityConfigurations
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(o => o.Id);

            builder.HasAlternateKey(o => o.SKU);

            builder
                .Property<String>(nameof(Product.Name))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Product.Name))
                .IsRequired();

            builder.HasOne<Inventory>(x => x.Inventory)
                   .WithOne(x => x.Product)
                   .HasForeignKey<Inventory>(x => x.ProductId);
        }
    }
}