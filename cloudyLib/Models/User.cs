using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Niepoprawny format email")]
        public string Email { get; set; } = null!;

        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } 

        [NotMapped] 
        [StringLength(100, MinimumLength = 6)] 
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = null!;

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
    }
}
