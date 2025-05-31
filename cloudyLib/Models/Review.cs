using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; } 

        public int UserId { get; set; } 
        public User User { get; set; } = null!;

        public int BookId { get; set; } 
        public Book Book { get; set; } = null!;

        [Required]
        public string Contents { get; set; } = null!; 

        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; } 
    }
}