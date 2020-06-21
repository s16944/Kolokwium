using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicLabelEntityTypeConfiguration : IEntityTypeConfiguration<MusicLabel>
    {
        public void Configure(EntityTypeBuilder<MusicLabel> builder)
        {
            builder.HasKey(m => m.IdMusicLabel);
            builder.Property(m => m.IdMusicLabel).UseIdentityColumn();
            
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}