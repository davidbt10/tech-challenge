using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entity;

namespace PI.Infrastructure.Configurations
{
    public class InvestmentPortfolioConfiguration : IEntityTypeConfiguration<InvestmentPortfolio>
    {
        public void Configure(EntityTypeBuilder<InvestmentPortfolio> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.UserId).IsRequired();

            builder.HasOne(i => i.User)
                .WithOne(u => u.InvestmentPortfolio)
                .HasForeignKey<InvestmentPortfolio>(i => i.UserId);
        }
    }
}
