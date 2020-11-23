using Interview.BusinessLogic.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.BusinessLogic.Products.Infrastructure
{
    internal sealed class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();

            builder
                .HasMany(x => x.OrderItems)
                .WithOne(x => x.Product)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static ProductMap GetInstance() => new ProductMap();
    }
}
