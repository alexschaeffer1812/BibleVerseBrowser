// Alex Schaeffer
// CST-247
// April 12, 2021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Models
{
    // This class is used for presenting the Bible verse in the _VerseCard partial
    public class BibleVerseViewModel
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }
    }
}
