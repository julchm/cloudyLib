using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudyLib.Models
{
    public class BookAuthor
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Book")]
        public int book_id { get; set; }
        public Book Book { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Author")]
        public int author_id { get; set; }
        public Author Author { get; set; }
    }
}
