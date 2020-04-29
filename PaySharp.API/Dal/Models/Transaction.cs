using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaySharp.API.Dal.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }

        public long SenderAccountID { get; set; }

        [ForeignKey("SenderAccountID")]
        [InverseProperty("SenderAccounts")]

        public Account SenderAccount { get; set; }


        public long ReceiverAccountID { get; set; }
        [ForeignKey("ReceiverAccountID")]
        [InverseProperty("ReceiverAccounts")]
        public Account ReceiverAccount { get; set; }

        [MaxLength(35)]
        public string Description { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


        public DateTime TimeStamp { get; set; }

        public long StatusId { get; set; }
        public Status Status { get; set; }


    }
}
