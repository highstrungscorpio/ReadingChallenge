using System.Collections;

namespace ReadingChallengeApi.Models
{
    public interface IBookRepository : IGenericRepository
    {
        void Add(Book book);
        void Update(Book book);
        Book Find(long key);
    }
}