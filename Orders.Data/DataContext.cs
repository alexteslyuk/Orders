using Microsoft.EntityFrameworkCore;
using Orders.Data.Configuration;
using Orders.Domain.Models;

namespace Orders.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.Entity<Provider>().HasData(new Provider (1, "Provider 1"));
            modelBuilder.Entity<Provider>().HasData(new Provider (2, "Provider 2"));
        }
    }
}
