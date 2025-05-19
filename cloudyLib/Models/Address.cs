using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Address
    {
        [Key]
        public int address_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string town { get; set; }

        [Required]
        [MaxLength(50)]
        public string voivodeship { get; set; }

        [Required]
        [MaxLength(6)]
        public string zip_code { get; set; }

        [Required]
        [MaxLength(50)]
        public string street { get; set; }

        [MaxLength(10)]
        public string apartment_number { get; set; }

        [MaxLength(10)]
        public string house_number { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
