using Crochet.Models;

namespace Crochet.Data.Repositories
{
    public interface IPatternsRepository
    {
        public List<PatternsModel> GetPatterns();
        public Task<PatternsModel> GetPatternsByIdAsync(int id);
        public Task<int> StorePatternsAsync(PatternsModel pattern);
        public int UpdatePatterns(PatternsModel pattern);
        public int DeletePatterns(int patternId);
    }
}
