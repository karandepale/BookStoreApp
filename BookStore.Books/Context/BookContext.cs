using BookStore.Books.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Books.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<BookEntity> Book { get; set; }
    }
}
