using System.ComponentModel.DataAnnotations;

namespace Crochet.Models
{
    public class LevelsModel
    {
        [Key]
        public string LevelId { get; set; }
        public string Level { get; set; }
    }
}
