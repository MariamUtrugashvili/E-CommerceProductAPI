using E_CommerceProduct.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace E_CommerceProduct.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150); 

            builder.HasIndex(x => x.Name);

            // Seed data
            builder.HasData(
                new Category { Id = Guid.NewGuid(), Name = "Electronics" },
                new Category { Id = Guid.NewGuid(), Name = "Clothing"},
                new Category { Id = Guid.NewGuid(), Name = "Books" },
                new Category { Id = Guid.NewGuid(), Name = "FoodAndBeverages" }

            );
        }
    }
}
