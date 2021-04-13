// Alex Schaeffer
// CST-247
// April 12, 2021

using BibleVerseBrowser.Models;
using BibleVerseBrowser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Controllers
{
    public class HomeController : Controller
    {
        public IBibleVerseRepository _bibleVerseRepository { get; set; }
        public IBookRepository _bookRepository { get; set; }
        private static Logger logger = LogManager.GetLogger("BibleVerseBrowserLoggerRule");

        // Handles dependency injection
        public HomeController(IBibleVerseRepository bibleVerseRepository, IBookRepository bookRepository)
        {
            _bibleVerseRepository = bibleVerseRepository;
            _bookRepository = bookRepository;
        }

        // This method returns the index view
        public IActionResult Index()
        {
            return View();
        }


        // This method gets the list of books based on the testament parameter
        [HttpGet]
        public ActionResult EnumerateBooks(string testament)
        {
            logger.Info("Entering the EnumerateBooks method");
            List<Book> bookList = _bookRepository.GetAllBooks();
            logger.Info("Exiting the EnumerateBooks method");
            return Json(bookList.Where(b => b.Testament == testament));
        }

        // This method gets the list of chapters based on the book id parameter
        [HttpGet]
        public ActionResult EnumerateChapters(string id)
        {
            logger.Info("Entering the EnumerateChapters method");
            int numberOfChapters = _bibleVerseRepository.GetNumberOfChapters(Int32.Parse(id));

            int[] values = Enumerable.Range(1, numberOfChapters).ToArray();
            logger.Info("Exiting the EnumerateChapters method");
            return Json(values);
        }

        // This method gets the list of books based on the testament parameter
        [HttpGet]
        public ActionResult EnumerateVerses(string id, string chapterNumber)
        {
            logger.Info("Entering the EnumerateVerses method");
            int numberOfVerses = _bibleVerseRepository.GetNumberOfVerses(Int32.Parse(id), Int32.Parse(chapterNumber));

            int[] values = Enumerable.Range(1, numberOfVerses).ToArray();
            logger.Info("Exiting the EnumerateVerses method");
            return Json(values);
        }

        // This method searches for the verse based on the search data from the SearchDTO
        public IActionResult SearchVerse(SearchDTO searchData)
        {
            logger.Info("Entering the SearchVerse method");
            List<BibleVerse> bibleVerses = _bibleVerseRepository.SearchBibleVerse(searchData.Book, searchData.ChapterNumber, searchData.VerseNumber);
            Book book = _bookRepository.GetBookById(searchData.Book);

            List<BibleVerseViewModel> result = new List<BibleVerseViewModel>();

            foreach (BibleVerse verse in bibleVerses)
            {
                result.Add(new BibleVerseViewModel { Book = _bookRepository.GetBookById(verse.Book).BookName, Chapter = verse.Chapter, Verse = verse.Verse, Text = verse.Text });
            }

            if (result.Count == 0)
            {
                ViewBag.Result = "No results found.";
                logger.Info("No results found from SearchVerse");
            }
            logger.Info("Exiting the SearchVerse method");
            return View("Index", result);
        }



    }
}
