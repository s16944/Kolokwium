using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(t => t.IdTrack);
            builder.Property(t => t.IdTrack).UseIdentityColumn();

            builder.Property(t => t.TrackName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Duration)
                .IsRequired();

            builder.HasOne(t => t.MusicAlbum)
                .WithMany(a => a.Tracks)
                .HasForeignKey(a => a.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}