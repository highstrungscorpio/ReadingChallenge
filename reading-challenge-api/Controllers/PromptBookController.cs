using System.Collections;
using Microsoft.AspNetCore.Mvc;
using ReadingChallengeApi.Models;

namespace ReadingChallengeApi.Controllers
{
    [ApiController]
    [Route("readingchallengeapi/[controller]")]
    public class PromptBookController : ControllerBase
    {
        public PromptBookController(IPromptBookRepository promptBooks)
        {
            PromptBooks = promptBooks;
        }

        public IPromptBookRepository PromptBooks { get; set; }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return PromptBooks.GetAll();
        }

        [HttpGet("{id}", Name = "GetPromptBook")]
        public IActionResult GetById(long id)
        {
            var promptBook = PromptBooks.Find(id);
            if (promptBook == null)
            {
                return NotFound();
            }
            return new ObjectResult(promptBook);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PromptBook promptBook)
        {
            if (promptBook == null)
            {
                return BadRequest();
            }
            PromptBooks.Add(promptBook);
            return CreatedAtRoute("GetPromptBook", new { id = promptBook.Id }, promptBook);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] PromptBook promptBook)
        {
            if (promptBook == null || promptBook.Id != id)
            {
                return BadRequest();
            }

            var found = PromptBooks.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            found.BookRead = promptBook.BookRead;
            found.DateRead = promptBook.DateRead;
            found.Prompts = promptBook.Prompts;

            PromptBooks.Update(found);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var found = PromptBooks.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            PromptBooks.Remove(id);
            return new NoContentResult();
        }
    }
}