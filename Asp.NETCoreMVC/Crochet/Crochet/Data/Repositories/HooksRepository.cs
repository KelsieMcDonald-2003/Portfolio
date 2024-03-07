using System.Collections.Generic;
using System.Linq;
using Crochet.Models;
using Crochet.Data;

namespace Crochet.Data.Repositories
{
    public class HooksRepository : IHooksRepository
    {
        private readonly AppDbContext context;
        public HooksRepository(AppDbContext c)
        {
            context = c;
        }

        public IEnumerable<HooksModel> GetAll() => context.Hooks.OrderBy(h => h.HookId).ToList();

        public HooksModel GetById(int id) => context.Hooks.Find(id);

        public void Add(HooksModel entity)
        {
            context.Hooks.Add(entity);
            context.SaveChanges();
        }

        public void Update(HooksModel entity)
        {
            context.Hooks.Update(entity);
            context.SaveChanges();
        }
    }
}