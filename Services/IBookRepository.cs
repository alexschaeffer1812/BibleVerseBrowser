using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
    }
}
