using System.Collections.Generic;

namespace Kolokwium.DTO
{
    public class MusicianResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public IEnumerable<TrackItem> Tracks { get; set; }
    }

    public class TrackItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
    }
}