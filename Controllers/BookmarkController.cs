using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookmarks.Models;
using Bookmarks.Models.Contracts;

namespace Bookmarks.Controllers
{
    public class BookmarkController : ApiController
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkController(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        // GET api/bookmark
        public IEnumerable<Bookmark> Get()
        {
            return _bookmarkRepository.GetAll();
        }

        // GET api/bookmark/5
        public HttpResponseMessage Get(int id)
        {
            var bookmark = _bookmarkRepository.Get(id);

            return bookmark != null
                       ? Request.CreateResponse(HttpStatusCode.OK, bookmark)
                       : Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/bookmark
        public HttpResponseMessage Post(Bookmark bookmark)
        {
            var b = _bookmarkRepository.Insert(bookmark);

            var response = Request.CreateResponse(HttpStatusCode.Created, b);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("bookmarks/{0}", b.Id));

            return response;
        }

        // PUT api/bookmark
        public HttpResponseMessage Put(Bookmark bookmark)
        {
            var b = _bookmarkRepository.Update(bookmark);

            var response = Request.CreateResponse(HttpStatusCode.Created, b);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("bookmarks/{0}", b.Id));

            return response;
        }

        // DELETE api/bookmark/5
        public HttpResponseMessage Delete(int id)
        {
            _bookmarkRepository.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
