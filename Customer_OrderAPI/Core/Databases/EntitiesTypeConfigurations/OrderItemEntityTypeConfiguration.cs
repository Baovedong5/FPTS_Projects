using Customer_OrderAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_OrderAPI.Core.Databases.EntitiesTypeConfigurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ProductName).HasColumnName("ProductName");
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Quantity).HasColumnName("Quantity");
        }
    }
}
