using System.Collections;
using Microsoft.AspNetCore.Mvc;
using ReadingChallengeApi.Models;

namespace ReadingChallengeApi.Controllers
{
    [ApiController]
    [Route("readingchallengeapi/[controller]")]
    public class BookController : ControllerBase
    {
        public BookController(IBookRepository books)
        {
            Books = books;
        }

        public IBookRepository Books { get; set; }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return Books.GetAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(long id)
        {
            var book = Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return new ObjectResult(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            Books.Add(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            var found = Books.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            found.Title = book.Title;
            found.Author = book.Author;
            found.AmazonLink = book.AmazonLink;

            Books.Update(found);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var found = Books.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            Books.Remove(id);
            return new NoContentResult();
        }
    }
}