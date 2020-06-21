using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        
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
        }
    }
}