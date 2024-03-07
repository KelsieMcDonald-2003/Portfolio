using System.ComponentModel.DataAnnotations;

namespace Crochet.Models
{
    public class HooksModel
    {
        [Key]
        public string HookId { get; set; }
        public string HookName { get; set; }
        public string HookSize { get; set; }
    }
}
