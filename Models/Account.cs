using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAppTwo.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public decimal AccountBalance { get; set; } = 0;


        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string BVN { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
    }
}

