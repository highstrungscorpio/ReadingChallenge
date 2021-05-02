using System.Collections;

namespace ReadingChallengeApi.Models
{
    public interface IPromptBookRepository : IGenericRepository
    {
        void Add(PromptBook promptBook);
        void Update(PromptBook promptBook);
        PromptBook Find(long key);
    }
}