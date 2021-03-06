// Alex Schaeffer
// CST-247
// April 12, 2021

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Models
{
    // This class represents a BibleVerse object
    public class BibleVerse
    {
        [Key]
        public int Id { get; set; }
        public int Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }
    }
}
