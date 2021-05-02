using System.Collections;

namespace ReadingChallengeApi.Models
{
    public interface IPromptRepository : IGenericRepository
    {
         void Add(Prompt prompt);
        void Update(Prompt prompt);
        Prompt Find(long key);
    }
}