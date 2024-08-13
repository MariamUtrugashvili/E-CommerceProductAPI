using E_CommerceProduct.Domain.Enums;
using E_CommerceProduct.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace E_CommerceProduct.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            var converter = new ValueConverter<CategoryName, string>(
                x => x.ToString(),
                x => (CategoryName)Enum.Parse(typeof(CategoryName), x));

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasConversion(converter)
                   .HasMaxLength(150); 

            builder.HasIndex(x => x.Name);

            // Seed data
            builder.HasData(
                new Category { Id = Guid.NewGuid(), Name = CategoryName.Electronics },
                new Category { Id = Guid.NewGuid(), Name = CategoryName.Clothing },
                new Category { Id = Guid.NewGuid(), Name = CategoryName.Books },
                new Category { Id = Guid.NewGuid(), Name = CategoryName.FoodAndBeverages }

            );
        }
    }
}
