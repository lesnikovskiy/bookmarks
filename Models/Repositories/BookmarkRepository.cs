using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Bookmarks.Models.Contracts;

namespace Bookmarks.Models.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly BookmarkContext _context;

        public BookmarkRepository()
        {
            _context = new BookmarkContext();
        }

        public IEnumerable<Bookmark> GetAll()
        {
            return _context.Bookmarks;
        }

        public Bookmark Get(int id)
        {
            return _context.Bookmarks.FirstOrDefault(b => b.Id == id);
        }

        public Bookmark Insert(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                foreach (var error in exc.EntityValidationErrors)
                {
                    foreach (var valError in error.ValidationErrors)
                    {
                        var err = error;
                    }
                }
            }
            

            return bookmark;
        }

        public Bookmark Update(Bookmark bookmark)
        {
            _context.Entry(bookmark).State = EntityState.Modified;
            _context.SaveChanges();

            return bookmark;
        }

        public bool Delete(int id)
        {
            var bookmark = Get(id);

            if (bookmark == null)
                return false;

            _context.Bookmarks.Remove(bookmark);
            _context.SaveChanges();
            return true;
        }
    }
}