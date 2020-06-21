using System.Collections;
using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public virtual Album MusicAlbum { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}