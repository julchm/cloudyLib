using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class BookLoan
    {
        [Key]
        public int BookLoanId { get; set; } 

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int UserId { get; set; } 
        public User User { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime LoanDate { get; set; } 

        [Column(TypeName = "date")]
        public DateTime? PlannedReturnDate { get; set; } 

        [Column(TypeName = "date")]
        public DateTime? ReturnDate { get; set; } 
    }
}