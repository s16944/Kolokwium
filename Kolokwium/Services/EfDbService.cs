using System;
using System.Linq;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services
{
    public class EfDbService : IDbService
    {
        private readonly MusicDbContext _dbContext;

        public EfDbService(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Musician GetMusicianWithTracksById(int musicianId)
        {
            var musician = _dbContext.Musicians
                .Include(m => m.MusicianTracks)
                .ThenInclude(mt => mt.Track)
                .FirstOrDefault(m => m.IdMusician == musicianId);

            if (musician == default) throw new NotFoundException();

            return musician;
        }

        public void AddMusicianWithTrack(Musician musician)
        {
            _dbContext.Database.BeginTransaction();

            var dbMusician = _dbContext.Musicians.FirstOrDefault(m =>
                m.FirstName == musician.FirstName &&
                m.LastName == musician.LastName &&
                m.Nickname == musician.Nickname
            );

            if (dbMusician != default) throw new ConflictException("Musician already exists");

            foreach (var mt in musician.MusicianTracks)
            {
                var track = mt.Track;
                mt.Track = _dbContext.Tracks.FirstOrDefault(t =>
                    t.TrackName == track.TrackName && Math.Abs(t.Duration - track.Duration) < 0.01f
                ) ?? track;
            }

            _dbContext.Musicians.Add(musician);
            _dbContext.SaveChanges();

            _dbContext.Database.CommitTransaction();
        }
    }
}