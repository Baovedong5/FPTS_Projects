using BasketAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketAPI.Core.Databases.EntitesTypeConfigurations
{
    public class BasketTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets");
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");

            var navigation = builder.Metadata.FindNavigation(nameof(Basket.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
