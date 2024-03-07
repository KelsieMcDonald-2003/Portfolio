using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crochet.Models
{
    public class PatternsModel
    {
        [Key]
        public int PatternId { get; set; }
        public string PatternTitle { get; set; } = string.Empty;
        public AppUserModel Publisher { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Hook")]
        public string HookId { get; set; } = string.Empty;
        public HooksModel Hook { get; set; } = null!;

        [ForeignKey("Level")]
        public string LevelId { get; set; } = string.Empty;
        public LevelsModel Level { get; set; } = null!;
        public string YarnBrand { get; set; } = string.Empty;
        public string YarnColor { get; set; } = string.Empty;
        public string PatternDescription { get; set; } = string.Empty;
        public string Pattern { get; set; } = string.Empty;
        public string Slug => PatternTitle?.Replace(' ', '-').ToLower();
    }
}
