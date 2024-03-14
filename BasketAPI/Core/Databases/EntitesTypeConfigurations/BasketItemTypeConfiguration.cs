using BasketAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketAPI.Core.Databases.EntitesTypeConfigurations
{
    public class BasketItemTypeConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.ProductId).HasColumnName("ProductId");
            builder.Property(x => x.ProductName).HasColumnName("ProductName");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.CustomerBasketId).HasColumnName("CustomerBasketId");

            builder.HasOne<Basket>(bi => bi.Basket)
                .WithMany(b => b.Items)
                .HasForeignKey(b => b.CustomerBasketId);
        }
    }
}
