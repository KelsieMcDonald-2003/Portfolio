using Crochet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crochet.Data.Repositories
{
    public class PatternsRepository : IPatternsRepository
    {
        AppDbContext context;
        public PatternsRepository(AppDbContext c)
        {
            context = c;
        }

        public async Task<PatternsModel> GetPatternsByIdAsync(int id)
        {
            var pattern = await context.Patterns.FindAsync(id);
            return pattern;
        }

        public List<PatternsModel> GetPatterns()
        {
            return context.Patterns
                .Include(h => h.Hook)
                .Include(l => l.Level)
                .ToList<PatternsModel>();
        }

        public async Task<int> StorePatternsAsync(PatternsModel model)
        {
            await context.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public int UpdatePatterns(PatternsModel pattern)
        {
            context.Update(pattern);
            return context.SaveChanges();
        }

        public int DeletePatterns(int patternId)
        {
            PatternsModel pattern = GetPatternsByIdAsync(patternId).Result;
            context.Patterns.Remove(pattern);
            return context.SaveChanges();
        }
    }
}