using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicianEntityTypeConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.HasKey(m => m.IdMusician);
            builder.Property(m => m.IdMusician).UseIdentityColumn();

            builder.Property(m => m.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(m => m.LastName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(m => m.Nickname).HasMaxLength(20);
        }
    }
}