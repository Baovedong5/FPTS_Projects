using Customer_OrderAPI.Core.Databases.EntitiesTypeConfigurations;
using Customer_OrderAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_OrderAPI.Core.Databases
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<OrderItem>(new OrderItemEntityTypeConfiguration());

            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(c => c.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
