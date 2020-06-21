using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class AlbumEntityTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(p => p.IdAlbum);
            builder.Property(p => p.IdAlbum).UseIdentityColumn();

            builder.Property(p => p.AlbumName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.PublishDate)
                .IsRequired();

            builder.HasOne(p => p.MusicLabel)
                .WithMany(l => l.Albums)
                .HasForeignKey(a => a.IdMusicLabel)
                .IsRequired();
        }
    }
}