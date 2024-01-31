using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entity;

namespace PI.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR(8)").IsRequired();
        }
    }
}
