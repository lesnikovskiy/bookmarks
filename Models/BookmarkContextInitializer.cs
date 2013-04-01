using System.Data.Entity;

namespace Bookmarks.Models
{
    public class BookmarkContextInitializer : DropCreateDatabaseIfModelChanges<BookmarkContext>
    {
        protected override void Seed(BookmarkContext context)
        {
            base.Seed(context);
        }
    }
}