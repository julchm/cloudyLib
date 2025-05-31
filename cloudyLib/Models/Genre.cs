using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        // Navigation property
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>(); 
    }
}