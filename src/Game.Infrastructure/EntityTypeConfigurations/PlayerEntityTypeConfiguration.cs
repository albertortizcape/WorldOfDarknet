using Game.Domain.Entities.PlayerAgrgegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Infraestructura.EntityTypeConfigurations
{
    class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {

            builder.HasKey(b => b.Id);
            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
