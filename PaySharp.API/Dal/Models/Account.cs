using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaySharp.API.Dal.Models
{
    public class Account
    {
        [Key]
        public long Id { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string AccountNumber { get; set; }

        [MinLength(3)]
        [MaxLength(35)]
        public string NickName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, Double.PositiveInfinity)]
        public decimal Balance { get; set; }


        public long ClientId { get; set; }
        public Client Client { get; set; }



        public ICollection<UsersAccounts> UsersAccounts { get; set; }

        public ICollection<Transaction> SenderAccounts { get; set; }

        public ICollection<Transaction> ReceiverAccounts { get; set; }
    }
}
