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
            try
            {
                var musician = _dbContext.Musicians
                    .Include(m => m.MusicianTracks)
                    .ThenInclude(mt => mt.Track)
                    .First(m => m.IdMusician == musicianId);

                return musician;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException();
            }
        }
    }
}