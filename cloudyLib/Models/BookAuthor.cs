using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloudyLib.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookId { get; set; } 
        public Book Book { get; set; } = null!; 

        [Key]
        public int AuthorId { get; set; } 
        public Author Author { get; set; } = null!; 
    }
}