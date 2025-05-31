using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class Rate
    {
        [Key]
        public int UserId { get; set; } 
        public User User { get; set; } = null!;

        [Key]
        public int BookId { get; set; } 
        public Book Book { get; set; } = null!;

        [Required]
        [Range(1, 5, ErrorMessage = "Ocena musi być od 1 do 5")]
        public int RateValue { get; set; } 
    }
}