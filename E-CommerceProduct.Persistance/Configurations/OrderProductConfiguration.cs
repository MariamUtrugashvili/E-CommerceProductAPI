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
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductQuantity)
                   .IsRequired();

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderProducts)
                   .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderProducts)
                   .HasForeignKey(x => x.ProductId);

            builder.HasIndex(x => new { x.OrderId, x.ProductId }).IsUnique();
        }
    }
}
