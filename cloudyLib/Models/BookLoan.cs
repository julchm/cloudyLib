using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class BookLoan
    {
        [Key]
        public int book_loan_id { get; set; }

        [ForeignKey("Book")]
        public int book_id { get; set; }
        public Book Book { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }

        [Column(TypeName = "date")]
        public DateTime loan_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime planned_return_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime return_date { get; set; }
    }
}
