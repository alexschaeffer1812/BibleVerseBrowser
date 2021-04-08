using BibleVerseBrowser.Models;
using BibleVerseBrowser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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


        public HomeController(IBibleVerseRepository bibleVerseRepository, IBookRepository bookRepository)
        {
            _bibleVerseRepository = bibleVerseRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            BindDropdowns();
            // EnumerateChapters(1);



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void BindDropdowns()
        {
            var list = _bookRepository.GetAllBooks();


            ViewBag.BookArray = list;
        }

        [HttpGet]
        public ActionResult EnumerateChapters(string id)
        {
            int numberOfChapters = _bibleVerseRepository.GetNumberOfChapters(Int32.Parse(id));

            int[] values = Enumerable.Range(1, numberOfChapters).ToArray();

            return Json(values);
        }

        [HttpGet]
        public ActionResult EnumerateVerses(string id, string chapterNumber)
        {
            int numberOfVerses = _bibleVerseRepository.GetNumberOfVerses(Int32.Parse(id), Int32.Parse(chapterNumber));

            int[] values = Enumerable.Range(1, numberOfVerses).ToArray();

            return Json(values);
        }

    }
}
