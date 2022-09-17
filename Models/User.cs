using System;
using System.ComponentModel.DataAnnotations;

namespace BankingAppTwo.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [Key, Required]
        public string BVN { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Pin { get; set; } = "0000";
        public string Email { get; set; } = String.Empty;

        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;


        public Account Account { get; set; }
    }
}

