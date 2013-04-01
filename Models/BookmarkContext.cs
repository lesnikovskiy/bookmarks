using System.Data.Entity;
namespace Bookmarks.Models
{
    public class BookmarkContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; } 
    }
}