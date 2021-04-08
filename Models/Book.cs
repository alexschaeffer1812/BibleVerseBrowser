using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Testament { get; set; }
        public int GenreId { get; set; }
        public int Chapters { get; set; }
        public int Verses { get; set; }
    }
}
