using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Dal.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<UsersClients> UsersClients { get; set; }
    }
}
