using System.Collections.Generic;
using System.Linq;
using Crochet.Models;
using Crochet.Data;

namespace Crochet.Data.Repositories
{
    public class LevelsRepository : ILevelsRepository
    {
        private readonly AppDbContext context;

        public LevelsRepository(AppDbContext c)
        {
            context = c;
        }

        public IEnumerable<LevelsModel> GetAll() => context.Levels.OrderBy(l => l.LevelId).ToList();

        public LevelsModel GetById(int id) => context.Levels.Find(id);

        public void Add(LevelsModel level)
        {
            context.Levels.Add(level);
            context.SaveChanges();
        }

        public void Update(LevelsModel level)
        {
            context.Levels.Update(level);
            context.SaveChanges();
        }
    }
}
