using BibleVerseBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Services
{
    public class BookRepository : IBookRepository
    {
        // Dependency Injection //

        private readonly DatabaseContext _dbContext;

        public BookRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implementation of IBibleVerseRepository using EntityFramework //

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            books = _dbContext.Books.ToList();

            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = _dbContext.Books.Where(b => b.Id == id).FirstOrDefault();

            return book;
        }


    }
}
