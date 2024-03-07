using System.Collections.Generic;
using Crochet.Models;

namespace Crochet.Data.Repositories
{
    public interface ILevelsRepository
    {
        IEnumerable<LevelsModel> GetAll();
        LevelsModel GetById(int id);
        void Add(LevelsModel level);
        void Update(LevelsModel level);
    }
}
