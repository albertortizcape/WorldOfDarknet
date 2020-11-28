using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Infraestructura.EntityTypeConfigurations
{
    class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {

            builder.HasKey(o => o.Id);
            builder
                .Property(o => o.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(p => p.Identity)
                .WithOne(i => i.Player);
        }

    }
}
