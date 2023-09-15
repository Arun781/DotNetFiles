using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class TeamModel
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        //public List<Player MyProperty { get; set; }

    }
}
