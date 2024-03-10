using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class CommentsModel
    {
        [Key]
        public int CommentId { get; set; }
        public AppUserModel User { get; set; }
        public string Comment { get; set; }
        public int StoryId { get; set; }
        public StoryModel Story { get; set; }
    }
}
