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
    public class ProductQuantityConfiguration : IEntityTypeConfiguration<ProductQuantity>
    {
        public void Configure(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.UpdatedAt);
  
            builder.HasIndex(x => x.ProductId);

            builder.HasOne(x => x.Product)
             .WithOne(x => x.ProductQuantity)
             .HasForeignKey<ProductQuantity>(x => x.ProductId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
