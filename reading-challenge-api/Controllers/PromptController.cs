using System.Collections;
using Microsoft.AspNetCore.Mvc;
using ReadingChallengeApi.Models;

namespace ReadingChallengeApi.Controllers
{
    [ApiController]
    [Route("readingchallengeapi/[controller]")]
    public class PromptController : ControllerBase
    {
        public PromptController(IPromptRepository prompts)
        {
            Prompts = prompts;
        }

        public IPromptRepository Prompts { get; set; }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return Prompts.GetAll();
        }

        [HttpGet("{id}", Name = "GetPrompt")]
        public IActionResult GetById(long id)
        {
            var prompt = Prompts.Find(id);
            if (prompt == null)
            {
                return NotFound();
            }
            return new ObjectResult(prompt);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Prompt prompt)
        {
            if (prompt == null)
            {
                return BadRequest();
            }
            Prompts.Add(prompt);
            return CreatedAtRoute("GetPrompt", new { id = prompt.Id }, prompt);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Prompt prompt)
        {
            if (prompt == null || prompt.Id != id)
            {
                return BadRequest();
            }

            var found = Prompts.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            found.Name = prompt.Name;
            found.Description = prompt.Description;

            Prompts.Update(found);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var found = Prompts.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            Prompts.Remove(id);
            return new NoContentResult();
        }
    }
}