using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class BookGenre
    {
        [Key]
        public int BookId { get; set; } 
        public Book Book { get; set; } = null!;

        [Key]
        public int GenreId { get; set; } 
        public Genre Genre { get; set; } = null!;
    }
}