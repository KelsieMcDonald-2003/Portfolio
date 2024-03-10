using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class StoryModel
    {
        [Key]
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string GenreId { get; set; }
        public GenreModel Genre { get; set; }
        public AppUserModel User { get; set; }
        public string StoryPlace { get; set; }
        public DateTime StoryDate { get; set; }
        public DateTime Date { get; set; }
        public string Story { get; set; }
        public ICollection<CommentsModel> Comments { get; set; }
    }
}
