using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleVerseBrowser.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleVerseBrowser.Services
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        // Tables in database
        public DbSet<BibleVerse> BibleVerses { get; set; }
        public DbSet<Book> Books { get; set; }



    }
}
