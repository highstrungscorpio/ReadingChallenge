using System.Collections;

namespace ReadingChallengeApi.Models
{
    public interface IGenericRepository
    {
        IEnumerable GetAll();
        void Remove(long key);

    }
}