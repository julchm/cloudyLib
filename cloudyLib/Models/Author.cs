using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Author
    {
        [Key]
        public int Author_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string First_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Last_name { get; set; }

        // Navigation property
        public ICollection<BookAuthor> BookAuthors { get; set; }
        
    }
}
