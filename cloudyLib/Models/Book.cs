using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(17)]
        public string? ISBN { get; set; }

        public short YearOfRelease { get; set; }
        public int AvailableCopies { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }

        // Navigation properties
        public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    }
}