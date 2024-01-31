using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entity;

namespace PI.Infrastructure.Configurations
{
    public class InvestmentPositionConfiguration : IEntityTypeConfiguration<InvestmentPosition>
    {
        public void Configure(EntityTypeBuilder<InvestmentPosition> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.AveragePrice).IsRequired();
            builder.Property(i => i.CreatedOn).IsRequired();
            builder.Property(i => i.LastModifiedOn);

            builder.HasOne(i => i.Asset)
                .WithMany()
                .HasForeignKey(i => i.AssetId);

            builder.HasOne(i => i.InvestmentPortfolio)
                .WithMany(ip => ip.Positions)
                .HasForeignKey(i => i.InvestmentPortfolioId);
        }
    }
}
