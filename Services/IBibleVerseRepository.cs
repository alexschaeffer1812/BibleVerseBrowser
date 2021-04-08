using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public interface IBibleVerseRepository
    {
        // Get Bible verse by Book, Chapter, and Verse
        BibleVerse SearchBibleVerse(int book, int chapter, int verse);
        // Get Bible verse by Id... probably don't need
        BibleVerse GetSingleBibleVerseById(int id);
        int GetNumberOfChapters(int bookId);
        int GetNumberOfVerses(int bookId, int chapterNumber);

    }
}
