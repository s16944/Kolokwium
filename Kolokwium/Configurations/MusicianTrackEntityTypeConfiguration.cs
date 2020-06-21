using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicianTrackEntityTypeConfiguration : IEntityTypeConfiguration<MusicianTrack>
    {
        public void Configure(EntityTypeBuilder<MusicianTrack> builder)
        {
            builder.HasKey(mt => mt.IdMusicianTrack);
            builder.Property(mt => mt.IdMusicianTrack).UseIdentityColumn();

            builder.HasOne(mt => mt.Musician)
                .WithMany(m => m.MusicianTracks)
                .HasForeignKey(mt => mt.IdMusician)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(mt => mt.Track)
                .WithMany(t => t.MusicianTracks)
                .HasForeignKey(t => t.IdTrack)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}