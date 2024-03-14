using BasketAPI.Core.Databases.EntitesTypeConfigurations;
using BasketAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Core.Databases
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Basket>(new BasketTypeConfiguration());
            modelBuilder.ApplyConfiguration<BasketItem>(new BasketItemTypeConfiguration());
        }
    }   
}
