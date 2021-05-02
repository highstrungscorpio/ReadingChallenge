using System;
using System.Collections;
using System.Linq;

namespace ReadingChallengeApi.Models
{
    public class PromptRepository : IPromptRepository
    {
        private readonly DataContext _context;

        public PromptRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable GetAll()
        {
            return _context.Prompts.ToList();
        }

        public void Add(Prompt prompt)
        {
            _context.Prompts.Add(prompt);
            _context.SaveChanges();
        }

        public Prompt Find(long id)
        {
            return _context.Prompts.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Prompts.First(t => t.Id == id);
            _context.Prompts.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Prompt prompt)
        {
            _context.Prompts.Update(prompt);
            _context.SaveChanges();
        }
    }
}