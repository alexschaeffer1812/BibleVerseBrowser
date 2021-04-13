// Alex Schaeffer
// CST-247
// April 12, 2021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Models
{
    // This DTO is used for passing the search data to the controller
    public class SearchDTO
    {
        public string Testament { get; set; }
        public int Book { get; set; }
        public int ChapterNumber { get; set; }
        public int VerseNumber { get; set; }
    }
}
