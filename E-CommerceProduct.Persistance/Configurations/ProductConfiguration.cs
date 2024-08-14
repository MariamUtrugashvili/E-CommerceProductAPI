using E_CommerceProduct.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceProduct.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.HasMany(x => x.Categories)
                   .WithMany(x => x.Products)
                   .UsingEntity(x => x.ToTable("ProductCategories"));

            builder.HasIndex(x => x.Name);
        }
    }
}
