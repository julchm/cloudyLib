using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class Genre
    {
        [Key]
        public int Genre_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
