using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Models
{
    public class AccountResponseModel
    {
        public long Id { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string AccountNumber { get; set; }

        [MinLength(3)]
        [MaxLength(35)]

        public string NickName { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity)]
        public decimal Balance { get; set; }

        public long UserId { get; set; }

        public bool IsAddedToUser { get; set; }

        public string ClientName { get; set; }
        public long ClientId { get; set; }
    }
}
