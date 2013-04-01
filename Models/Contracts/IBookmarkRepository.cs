using System.Collections.Generic;

namespace Bookmarks.Models.Contracts
{
    public interface IBookmarkRepository
    {
        IEnumerable<Bookmark> GetAll();
        Bookmark Get(int id);
        Bookmark Insert(Bookmark bookmark);
        Bookmark Update(Bookmark bookmark);
        bool Delete(int id);
    }
}