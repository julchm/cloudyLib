using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Review
    {
        [Key]
        public int Review_id { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

        [ForeignKey("Book")]
        public int Book_id { get; set; }
        public Book Book { get; set; }

        [Required]
        public string Contents { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_added { get; set; }
    }
}
