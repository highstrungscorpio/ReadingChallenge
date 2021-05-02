using System;
using System.Collections;
using System.Linq;

namespace ReadingChallengeApi.Models
{
    public class PromptBookRepository : IPromptBookRepository
    {
        private readonly DataContext _context;

        public PromptBookRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable GetAll()
        {
            return _context.PromptBooks.ToList();
        }

        public void Add(PromptBook promptBook)
        {
            _context.PromptBooks.Add(promptBook);
            _context.SaveChanges();
        }

        public PromptBook Find(long id)
        {
            return _context.PromptBooks.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = _context.PromptBooks.First(t => t.Id == id);
            _context.PromptBooks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(PromptBook promptBook)
        {
            _context.PromptBooks.Update(promptBook);
            _context.SaveChanges();
        }
    }
}