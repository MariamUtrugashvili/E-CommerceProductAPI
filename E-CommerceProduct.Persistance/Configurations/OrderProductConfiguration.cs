using E_CommerceProduct.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderProducts)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.OrderId, x.ProductId }).IsUnique();
        }
    }
}
