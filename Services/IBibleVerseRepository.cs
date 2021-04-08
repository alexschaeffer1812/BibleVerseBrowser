using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public interface IBibleVerseRepository
    {
        BibleVerse SearchBibleVerse(int book, int chapter, int verse);
        BibleVerse GetSingleBibleVerseById(int id);

    }
}
