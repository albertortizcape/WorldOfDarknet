using Game.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Infrastructure.EntityTypeConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
            builder
                .HasIndex(o => o.Email)
                .IsUnique();

            builder
                .Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(o => o.PasswordHash)
                .IsRequired();

            builder
                .Property(o => o.PasswordSalt)
                .IsRequired();
        }
    }
}
