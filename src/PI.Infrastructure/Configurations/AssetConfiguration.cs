using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entity;

namespace PI.Infrastructure.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Symbol).IsRequired();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Price).IsRequired();

            //builder.HasMany(a => a.InvestmentPositions)
            //    .WithOne(i => i.Asset)
            //    .HasForeignKey(i => i.Assetd);
        }
    }
}
