using Interview.BusinessLogic.Orders.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.BusinessLogic.Orders.Infrastructure
{
    internal sealed class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Total).HasPrecision(10, 2).IsRequired();

            builder
                .HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        public static OrderMap GetInstance() => new OrderMap();
    }
    
    internal sealed class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems);

            builder
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderItems)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static OrderItemMap GetInstance() => new OrderItemMap();
    }
}
