using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public class BibleVerseRepository : IBibleVerseRepository
    {
        // Dependency Injection //

        private readonly DatabaseContext _dbContext;

        public BibleVerseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implementation of IBibleVerseRepository using EntityFramework //


        public BibleVerse GetSingleBibleVerseById(int id)
        {
            var bibleVerse = _dbContext.BibleVerses.Where(v => v.Id == id).FirstOrDefault();

            return bibleVerse;
        }

        public BibleVerse SearchBibleVerse(int book, int chapter, int verse)
        {
            var bibleVerse = _dbContext.BibleVerses.Where(v => v.Book == book).Where(v => v.Chapter == chapter).Where(v => v.Verse == verse).FirstOrDefault();

            return bibleVerse;
        }

        public int GetNumberOfChapters(int bookId)
        {
            List<BibleVerse> versesInBook = _dbContext.BibleVerses.Where(v => v.Book == bookId).ToList();

            int numberOfChaptersInBook = versesInBook.Select(v => v.Chapter).Distinct().Count();

            return numberOfChaptersInBook;

        }

        public int GetNumberOfVerses(int bookId, int chapterNumber)
        {
            List<BibleVerse> versesInBook = _dbContext.BibleVerses.Where(v => v.Book == bookId).Where(v => v.Chapter == chapterNumber).ToList();

            int numberOfVersesInChapter = versesInBook.Select(v => v.Verse).Count();

            return numberOfVersesInChapter;
        }

    }
}
