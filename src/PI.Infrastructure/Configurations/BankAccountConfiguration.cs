using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entity;

namespace PI.Infrastructure.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Balance).IsRequired();
            builder.Property(b => b.CreatedOn).IsRequired();
            builder.Property(b => b.LastModifiedOn);

            builder.HasOne(b => b.User)
                .WithOne(u => u.BankAccount)
                .HasForeignKey<BankAccount>(b => b.UserId);
        }
    }
}
