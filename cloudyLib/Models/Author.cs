using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cloudyLib.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        // Navigation property
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>(); 
    }
}