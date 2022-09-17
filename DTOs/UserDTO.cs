using System;
using System.ComponentModel.DataAnnotations;

namespace BankingAppTwo.DTOs
{
    public class UserDTO
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Pin { get; set; }
        [Required]
        public string BVN { get; set; }
        [Required]
        public string Email { get; set; } 

    }
}

