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
        public int book_id { get; set; }

        [ForeignKey("Author")]
        public int author_id { get; set; }
        public Author Author { get; set; }

        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        [MaxLength(17)]
        public string? isbn { get; set; }

        public short year_of_release { get; set; }

        public bool availability { get; set; }

        public DateTime date_added { get; set; }

        public int number_of_loans { get; set; }

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public object Authors { get; set; }
    }
}
