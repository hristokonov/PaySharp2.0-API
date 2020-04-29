using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Dal.Models
{
    public class Admin
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(16)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public long RoleId { get; set; }
        public Role Role { get; set; }


    }
}
