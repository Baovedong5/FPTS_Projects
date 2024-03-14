using Microsoft.EntityFrameworkCore;
using ProductAPI.Core.Models;

namespace ProductAPI.Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
