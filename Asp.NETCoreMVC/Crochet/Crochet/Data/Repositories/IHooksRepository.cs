using System.Collections.Generic;
using Crochet.Models;

namespace Crochet.Data.Repositories
{
    public interface IHooksRepository
    {
        IEnumerable<HooksModel> GetAll();
        HooksModel GetById(int id);
        void Add(HooksModel entity);
        void Update(HooksModel entity);
    }
}
