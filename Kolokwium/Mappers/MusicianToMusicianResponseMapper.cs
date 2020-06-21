using System.Collections.Generic;
using System.Linq;
using Kolokwium.DTO;
using Kolokwium.Models;

namespace Kolokwium.Mappers
{
    public class MusicianToMusicianResponseMapper : IMapper<Musician, MusicianResponse>
    {
        public MusicianResponse Map(Musician data) => new MusicianResponse
        {
            Id = data.IdMusician,
            FirstName = data.FirstName,
            LastName = data.LastName,
            Nickname = data.Nickname,
            Tracks = retrieveTracks(data)
        };

        private IEnumerable<TrackItem> retrieveTracks(Musician data) =>
            data.MusicianTracks
                .Select(mt => mt.Track)
                .Select(t => new TrackItem
                {
                    Id = t.IdTrack,
                    Name = t.TrackName,
                    Duration = t.Duration
                });
    }
}