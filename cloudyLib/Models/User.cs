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
        public int user_id { get; set; }

        [Required]
        [MaxLength(30)]
        public string first_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string last_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(12)]
        public string phone_number { get; set; }

        [ForeignKey("Address")]
        public int address_id { get; set; }
        public Address Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string role { get; set; }

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
