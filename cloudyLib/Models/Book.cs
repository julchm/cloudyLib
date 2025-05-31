using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Book
    {
        [Key]
        public int Book_id { get; set; }

        [ForeignKey("Author")]
        public int Author_id { get; set; }
        public Author Author { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(17)]
        public string? ISBN { get; set; }

        public short Year_of_release { get; set; }

        public bool Availability { get; set; }

        public DateTime Date_added { get; set; }

        public int Number_of_loans { get; set; }

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
