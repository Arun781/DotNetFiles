using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class VenueModel
    {
        [Key]
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueURL { get; set; }
        public string VenueDesc { get; set; }
        public string VenueLocal { get; set; }

    }
}
