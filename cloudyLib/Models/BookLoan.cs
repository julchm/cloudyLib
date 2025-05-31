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
        public int Book_loan_id { get; set; }

        [ForeignKey("Book")]
        public int Book_id { get; set; }
        public Book Book { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

        [Column(TypeName = "date")]
        public DateTime Loan_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Planned_return_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Return_date { get; set; }
    }
}
