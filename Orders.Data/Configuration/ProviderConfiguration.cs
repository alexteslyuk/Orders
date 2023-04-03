using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;

namespace Orders.Data.Configuration
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany<Order>()
                .WithOne()
                .HasForeignKey(o => o.ProviderId);
            builder.Property(p => p.Name)
                .HasColumnType("varchar");
        }
    }
}
