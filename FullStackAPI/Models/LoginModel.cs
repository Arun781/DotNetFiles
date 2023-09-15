using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }


    }
}
