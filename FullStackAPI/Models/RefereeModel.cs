using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class RefereeModel
    {
        [Key]
        public int RefereeID { get; set; }
        public string RefereeName { get; set; }
        public int NoOfMatches { get; set; }

    }
}
