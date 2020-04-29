using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Dal.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(35)]
        public string Name { get; set; }

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

        public ICollection<UsersAccounts> UsersAccounts { get; set; }
        public ICollection<UsersClients> UsersClients { get; set; }

    }
}
