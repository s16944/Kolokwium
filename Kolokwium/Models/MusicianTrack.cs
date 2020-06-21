namespace Kolokwium.Models
{
    public class MusicianTrack
    {
        public int IdMusicianTrack { get; set; }
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Musician Musician { get; set; }
        public Track Track { get; set; }
    }
}