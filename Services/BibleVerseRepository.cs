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

        public List<BibleVerse> SearchBibleVerse(int book, int chapter, int verse)
        {
            var query = _dbContext.BibleVerses.Where(v => v.Book == book);

            if (chapter != 0)
            {
                query = query.Where(v => v.Chapter == chapter);
            }

            if (verse != 0)
            {
                query = query.Where(v => v.Verse == verse);
            }

            var result = query.ToList();

            return result;
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
