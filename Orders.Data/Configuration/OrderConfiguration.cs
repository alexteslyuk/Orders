using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;

namespace Orders.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasMany<OrderItem>()
                .WithOne()
                .HasForeignKey(i => i.OrderId);
            builder.Property(o => o.Number)
                .HasColumnType("varchar");
            builder.Property(o => o.Date)
                .HasColumnType("datetime2")
                .HasPrecision(7);
            builder.HasIndex(new string[] { "Number", "ProviderId" }).IsUnique();
        }
    }
}
