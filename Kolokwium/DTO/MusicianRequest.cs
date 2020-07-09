using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.DTO
{
    public class MusicianRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public NewTrackItem Track { get; set; }
    }

    public class NewTrackItem
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
    }
}