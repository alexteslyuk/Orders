using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;

namespace Orders.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name)
                .HasColumnType("varchar");
            builder.Property(i => i.Quantity)
                .HasPrecision(18, 3);
            builder.Property(i => i.Unit)
                .HasColumnType("varchar");
        }
    }
}
