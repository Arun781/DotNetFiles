using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class EventModel
    {
        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string EventAddress { get; set; }
        public DateTime EventFromDate { get; set; }
        public DateTime EventToDate { get; set; }

    }
}
