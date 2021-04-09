using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Models
{
    public class SearchDTO
    {
        public string Testament { get; set; }
        public int Book { get; set; }
        public int ChapterNumber { get; set; }
        public int VerseNumber { get; set; }
    }
}
