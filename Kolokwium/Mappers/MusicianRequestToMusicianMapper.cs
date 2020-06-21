using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kolokwium.DTO;
using Kolokwium.Models;

namespace Kolokwium.Mappers
{
    public class MusicianRequestToMusicianMapper : IMapper<MusicianRequest, Musician>
    {
        public Musician Map(MusicianRequest data)
        {
            var musician = new Musician
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nickname = data.Nickname
            };
            musician.MusicianTracks = createMusicianTracks(data, musician);
            return musician;
        }

        private ICollection<MusicianTrack> createMusicianTracks(MusicianRequest data, Musician musician) =>
            data.Tracks
                .Select(t => new Track
                {
                    TrackName = t.Name,
                    Duration = t.Duration
                })
                .Select(t => new MusicianTrack
                {
                    Musician = musician,
                    Track = t
                }).ToList();
    }
}