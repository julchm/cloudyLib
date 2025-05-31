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
        public int User_id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        public string Last_Name { get; set; }


        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Niepoprawny format email")]
        public string Email { get; set; }

        [MaxLength(12)]
        [Phone(ErrorMessage = "Niepoprawny format numeru telefonu")]
        public string Phone_number { get; set; }


        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MaxLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
