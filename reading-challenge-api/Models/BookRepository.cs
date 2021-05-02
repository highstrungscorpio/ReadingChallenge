using System;
using System.Collections;
using System.Linq;

namespace ReadingChallengeApi.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable GetAll()
        {
            return _context.Books.ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book Find(long id)
        {
            return _context.Books.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Books.First(t => t.Id == id);
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}