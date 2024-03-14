using Customer_OrderAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_OrderAPI.Core.Databases.EntitiesTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(o => o.OrderDate).HasColumnName("OrderDate");
            builder.Property(o => o.CustomerId).HasColumnName("CustomerId");
            builder.Property(o => o.Street).HasColumnName("Street");
            builder.Property(o => o.City).HasColumnName("City");
            builder.Property(o => o.District).HasColumnName("District");
            builder.Property(o => o.AdditionalAddress).HasColumnName("AdditionalAddress");
        }
    }
}
