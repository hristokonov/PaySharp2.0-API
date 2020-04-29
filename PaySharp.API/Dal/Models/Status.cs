using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Dal.Models
{
    public class Status
    {
        public long Id { get; set; }

        [Required]
        public string StatusName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
