using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public class BibleVerseRepository : IBibleVerseRepository
    {
        private readonly DatabaseContext _dbContext;

        public BibleVerseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


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

    }
}
