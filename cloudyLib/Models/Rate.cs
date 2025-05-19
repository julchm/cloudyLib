using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Rate
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Book")]
        public int book_id { get; set; }
        public Book Book { get; set; }

        [Required]
        public byte rate_value { get; set; }
    }
}
