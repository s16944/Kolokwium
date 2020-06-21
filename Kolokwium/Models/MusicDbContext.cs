using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        
        protected MusicDbContext()
        {
        }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MusicianEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MusicLabelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MusicianTrackEntityTypeConfiguration());
        }
    }
}