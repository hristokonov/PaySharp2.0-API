using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Models
{
    public class LoginModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(16)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
