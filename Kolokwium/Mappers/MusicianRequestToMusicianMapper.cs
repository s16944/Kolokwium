using System.Collections.Generic;
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
            musician.MusicianTracks = CreateMusicianTracks(data, musician);
            return musician;
        }

        private ICollection<MusicianTrack> CreateMusicianTracks(MusicianRequest data, Musician musician)
        {
            if (data.Track == default) return new List<MusicianTrack>();
            var track = new Track
            {
                TrackName = data.Track.Name,
                Duration = data.Track.Duration
            };
            return new List<MusicianTrack>
            {
                new MusicianTrack
                {
                    Musician = musician,
                    Track = track
                }
            };
        }
    }
}