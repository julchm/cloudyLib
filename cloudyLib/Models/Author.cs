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
        public int author_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string first_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string last_name { get; set; }

        // Navigation property
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public object Books { get;  set; }
    }
}
